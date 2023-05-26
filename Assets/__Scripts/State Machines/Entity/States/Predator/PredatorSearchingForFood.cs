using Game.Interaction;
using Game.Interaction.Consume;
using Game.Movement;
using UnityEngine;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorSearchingForFood : EntityState
    {
        public override string Name => "Predator Searching For Food";

        private EntityInteractor _interactor;
        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;

        public PredatorSearchingForFood(EntityStateMachine stateMachine, EntityInteractor interactor, EntityMovement movement, EntityDestinationPicker destinationPicker) : base(stateMachine)
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

            if (_interactor.TryGetClosestAvailableInteractable(typeof(Food), out IInteractable interactable) == true)
            {
                Machine.SetState<PredatorFoundFood>();
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
