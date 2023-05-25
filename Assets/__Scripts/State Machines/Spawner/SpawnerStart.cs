namespace Game.StateMachines
{
    public class SpawnerStart : State
    {
        public override string Name => "Spawner Start";

        public SpawnerStart(SpawnerStateMachine stateMachine) : base(stateMachine)
        {

        }
    }
}
