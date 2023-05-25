namespace Game.StateMachines
{
    public class EntityState : State
    {
        protected new EntityStateMachine Machine { get; private set; }
        public EntityState(EntityStateMachine stateMachine) : base(stateMachine)
        {
            Machine = stateMachine;
        }
    }
}
