using Game.Interaction;
using Game.Interaction.Consume;
using Game.Movement;
using UnityEngine;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorFoundWater : EntityState
    {
        public override string Name => "Predator Found Water";

        private EntityInteractor _interactor;
        private EntityMovement _movement;
        private IInteractable _interactable;

        public PredatorFoundWater(EntityStateMachine stateMachine, EntityInteractor interactor, EntityMovement movement) : base(stateMachine)
        {
            _interactor = interactor;
            _movement = movement;
        }

        public override void Enter()
        {
            base.Enter();

            if (_interactor.TryGetClosestAvailableInteractable(typeof(WaterSource), out IInteractable interactable) == true)
            {
                _interactable = interactable;
                _movement.SetDestination(_interactable.Self.transform.position);
                return;
            }

            Machine.SetState<PredatorIdle>();
            return;
        }

        public override void Update()
        {
            base.Update();

            if (_movement.IsCloseToDestination == true)
            {
                Machine.SetState<PredatorConsuming>();
                return;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
