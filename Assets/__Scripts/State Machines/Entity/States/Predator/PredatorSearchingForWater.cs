using UnityEngine;
using Game.Interaction;
using Game.Movement;
using Game.Interaction.Consume;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorSearchingForWater : EntityState
    {
        public override string Name => "Predator Searching For Water";

        private EntityInteractor _interactor;
        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;

        public PredatorSearchingForWater(EntityStateMachine stateMachine, EntityInteractor interactor, EntityMovement movement, EntityDestinationPicker destinationPicker) : base(stateMachine)
        {
            _interactor = interactor;
            _movement = movement;
            _destinationPicker = destinationPicker;
        }

        public override void Enter()
        {
            base.Enter();


            _destinationPicker.SetPointRandomDestinationInDistance();
            _movement.SetDestination(_destinationPicker.Point);
        }

        public override void Update()
        {
            base.Update();

            if (_interactor.TryGetClosestAvailableInteractable(typeof(WaterSource), out IInteractable interactable) == true)
            {
                Machine.SetState<PredatorFoundWater>();
                return;
            }

            if (_movement.IsCloseToDestination == true)
            {
                Machine.SetState<PredatorIdle>();
                return;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
