using Game.Movement;

namespace Game.StateMachines.Entity
{
    public class EntitySearchingForDestination : EntityState
    {
        public override string Name => "Entity Searching For Destination";


        private EntityDestinationPicker _destinationPicker;

        public EntitySearchingForDestination(EntityStateMachine stateMachine, EntityDestinationPicker destinationPicker) : base(stateMachine)
        {
            _destinationPicker = destinationPicker;
        }

        public override void Enter()
        {
            base.Enter();

            _destinationPicker.GetRandomDestinationInDistance();
            Machine.SetState<EntityMoving>();
        }
    }
}
