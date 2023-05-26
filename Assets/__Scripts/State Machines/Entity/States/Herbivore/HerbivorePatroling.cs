using Game.Movement;

namespace Game.StateMachines.Entities.Herbivore
{
    public class HerbivorePatroling : EntityState
    {
        public override string Name => "Herbivore Patroling";

        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;

        public HerbivorePatroling(EntityStateMachine stateMachine, EntityMovement movement, EntityDestinationPicker destinationPicker) : base(stateMachine)
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

            Machine.SetState<HerbivoreIdle>();
        }

        public override void Exit()
        {
            base.Exit();

            _movement.ResetDestination();
        }
    }
}
