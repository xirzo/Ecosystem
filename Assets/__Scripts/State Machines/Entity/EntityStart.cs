using UnityEngine;

namespace Game.StateMachines
{
    public class EntityStart : EntityState
    {
        public EntityStart(EntityStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            Machine.SetState<EntityIdle>();
        }
    }
}
