using UnityEngine;

namespace Game.StateMachines.Entity
{
    public class EntityStart : EntityState
    {
        public override string Name => "Entity Start";

        public EntityStart(EntityStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            Machine.SetState<EntityIdle>();
        }
    }
}
