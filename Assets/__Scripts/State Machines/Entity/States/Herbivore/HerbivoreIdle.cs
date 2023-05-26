using Game.Stats;
using UnityEngine;

namespace Game.StateMachines.Entities.Herbivore
{
    public class HerbivoreIdle : EntityState
    {
        public override string Name => "Herbivore Idle";

        private Satiety _satiety;
        private Thirst _thirst;

        public HerbivoreIdle(EntityStateMachine stateMachine, Satiety satiety, Thirst thirst) : base(stateMachine)
        {
            _satiety = satiety; 
            _thirst = thirst;
        }

        public override void Enter()
        {
            base.Enter();

            if (_thirst.IsThirsty() == true)
            {
                Machine.SetState<HerbivoreSearchingForWater>();
                return;
            }

            if (_satiety.IsHungry() == true)
            {
                Machine.SetState<HerbivoreSearchingForFood>();
                return;
            }

            Machine.SetState<HerbivorePatroling>();
        }
    }
}
