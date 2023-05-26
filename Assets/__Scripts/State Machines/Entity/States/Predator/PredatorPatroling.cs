using Game.Movement;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorPatroling : EntityState
    {
        public override string Name => "Predator Patroling";

        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;

        public PredatorPatroling(EntityStateMachine stateMachine, EntityMovement movement, EntityDestinationPicker destinationPicker) : base(stateMachine)
        {
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

            if (_movement.DistanceToDestination > _movement.StoppingDistance)
            {
                return;
            }

            Machine.SetState<PredatorIdle>();
        }

        public override void Exit()
        {
            base.Exit();

            _movement.ResetDestination();
        }
    }
}
