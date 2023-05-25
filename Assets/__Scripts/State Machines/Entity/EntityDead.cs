using UnityEngine;

namespace Game.StateMachines.Entity
{
    public class EntityDead : EntityState
    {
        public override string Name => "Entity Dead";

        public EntityDead(EntityStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {

        }
    }
}
