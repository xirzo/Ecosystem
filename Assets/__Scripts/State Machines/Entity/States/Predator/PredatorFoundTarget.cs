using Game.Movement;
using Game.Targeting;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorFoundTarget : EntityState
    {
        public override string Name => "Predator Found Target";

        private EntityMovement _movement;
        private Targeter _targeter;

        public PredatorFoundTarget(EntityStateMachine stateMachine, EntityMovement movement, Targeter targeter) : base(stateMachine)
        {
            _movement = movement;
            _targeter = targeter;
        }

        public override void Enter()
        {
            base.Enter();

            if (_targeter.Target == null)
            {
                Machine.SetState<PredatorSearchingForFood>();
                return;
            }
        }

        public override void Update()
        {
            base.Update();

            _movement.SetDestination(_targeter.Target.position);

            if (_movement.IsCloseToDestination == true)
            {
                Machine.SetState<PredatorAttacking>();
                return;
            }
        }
    }
}
