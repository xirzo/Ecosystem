using Game.Attacking;
using Game.Interaction;
using Game.Movement;
using Game.Stats;
using Game.Targeting;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorAttacking : EntityState
    {
        public override string Name => "Predator Attacking";

        private EntityInteractor _interactor;
        private EntityMovement _movement;
        private ITargeter _targeter;
        private IAttacker _attacker;

        public PredatorAttacking(EntityStateMachine stateMachine, EntityInteractor interactor, EntityMovement movement, ITargeter targeter, IAttacker attacker) : base(stateMachine)
        {
            _interactor = interactor;
            _movement = movement;
            _targeter = targeter;
            _attacker = attacker;
        }

        public override void Enter()
        {
            base.Enter();

            _targeter.Target.TryGetComponent(out Health health);
            _movement.ResetDestination();
            _attacker.Attack(health);
        }

        public override void Update()
        {
            base.Update();

            if (_attacker.IsAttacking == false)
            {
                Machine.SetState<PredatorSearchingForFood>();
                return;
            }
        }
    }
}
