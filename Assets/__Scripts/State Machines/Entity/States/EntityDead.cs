using UnityEngine;

namespace Game.StateMachines.Entities.Herbivore
{
    public class EntityDead : EntityState
    {
        public override string Name => "Entity Dead";

        public EntityDead(EntityStateMachine stateMachine) : base(stateMachine)
        {

        }

    }
}
