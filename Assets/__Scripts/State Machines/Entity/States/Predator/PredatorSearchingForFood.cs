using Game.Interaction;
using Game.Interaction.Consume;
using Game.Movement;
using Game.Targeting;
using UnityEngine;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorSearchingForFood : EntityState
    {
        public override string Name => "Predator Searching For Food";

        private EntityInteractor _interactor;
        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;
        private Targeter _targeter;

        public PredatorSearchingForFood(EntityStateMachine stateMachine, EntityInteractor interactor, EntityMovement movement, EntityDestinationPicker destinationPicker, Targeter targeter) : base(stateMachine)
        {
            _interactor = interactor;
            _movement = movement;
            _destinationPicker = destinationPicker;
            _targeter = targeter;
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

            if (_targeter.CanSeeTarget == true)
            {
                Machine.SetState<PredatorFoundTarget>();
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
