using Game.Stats;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorIdle : EntityState
    {
        public override string Name => "Predator Idle";

        private Satiety _satiety;
        private Thirst _thirst;

        public PredatorIdle(EntityStateMachine stateMachine, Satiety satiety, Thirst thirst) : base(stateMachine)
        {
            _satiety = satiety;
            _thirst = thirst;
        }

        public override void Enter()
        {
            base.Enter();

            if (_thirst.IsThirsty() == true)
            {
                Machine.SetState<PredatorSearchingForWater>();
                return;
            }

            if (_satiety.IsHungry() == true)
            {
                Machine.SetState<PredatorSearchingForFood>();
                return;
            }

            Machine.SetState<PredatorPatroling>();
        }
    }
}
