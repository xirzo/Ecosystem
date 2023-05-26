using Game.Interaction;
using Game.Interaction.Consume;
using Game.Movement;
using UnityEngine;

namespace Game.StateMachines.Entities.Herbivore
{
    public class HerbivoreFoundFood : EntityState
    {
        public override string Name => "Herbivore Found Food";

        private EntityInteractor _interactor;
        private EntityMovement _movement;
        private IInteractable _interactable;

        public HerbivoreFoundFood(EntityStateMachine stateMachine, EntityInteractor interactor, EntityMovement movement) : base(stateMachine)
        {
            _interactor = interactor;
            _movement = movement;
        }

        public override void Enter()
        {
            base.Enter();

            if (_interactor.TryGetClosestAvailableInteractable(typeof(Food), out IInteractable interactable) == true)
            {
                _interactable = interactable;
                _movement.SetDestination(_interactable.Self.transform.position);
                return;
            }

            Machine.SetState<HerbivoreIdle>();
            return;
        }

        public override void Update()
        {
            base.Update();

            if (_movement.IsCloseToDestination == true)
            {
                Machine.SetState<HerbivoreConsuming>();
                return;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
