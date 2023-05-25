namespace Game.StateMachines
{
    public abstract class SpawnerState : State
    {
        protected new SpawnerStateMachine Machine { get; private set; }
        public SpawnerState(SpawnerStateMachine stateMachine) : base(stateMachine)
        {
            Machine = stateMachine;
        }
    }
}
