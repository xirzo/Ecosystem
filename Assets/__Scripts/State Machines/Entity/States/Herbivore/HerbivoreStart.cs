using UnityEngine;

namespace Game.StateMachines.Entities.Herbivore
{
    public class HerbivoreStart : EntityState
    {
        public override string Name => "Herbivore Start";

        public HerbivoreStart(EntityStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            Machine.SetState<HerbivoreIdle>();
        }
    }
}
