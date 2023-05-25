using UnityEngine;

namespace Game.StateMachines.Entity
{
    public class EntityIdle : EntityState
    {
        public override string Name => "Entity Idle";

        public EntityIdle(EntityStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();

            Machine.SetState<EntitySearchingForDestination>();
        }
    }
}
