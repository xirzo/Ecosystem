using UnityEngine;

namespace Game.StateMachines
{
    public class EntityIdle : EntityState
    {
        public EntityIdle(EntityStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();

            Machine.SetState<EntitySearchForDestination>();
        }
    }
}
