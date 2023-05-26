using UnityEngine;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorStart : EntityState
    {
        public override string Name => "Predator Start";

        public PredatorStart(EntityStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            Machine.SetState<PredatorIdle>();
        }
    }
}
