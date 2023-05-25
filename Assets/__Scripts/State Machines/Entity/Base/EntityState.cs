namespace Game.StateMachines.Entity
{
    public abstract class EntityState : State
    {
        protected new EntityStateMachine Machine { get; private set; }

        public EntityState(EntityStateMachine stateMachine) : base(stateMachine)
        {
            Machine = stateMachine;
        }
    }
}
