using Game.Attacking;
using Game.Consuming;
using Game.Movement;
using Game.Stats;
using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(IMovement))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(ConsumerBehaviour))]
    public class EntityAnimator : AnimatorBehavior
    {
        private const string IS_WALKING = "isWalking";
        private const string IS_STANDING = "isStanding";
        private const string IS_RUNNING = "isRunning";
        private const string IS_EATING = "isEating";
        private const string IS_ATTACKING = "isAttacking";

        private const string DEATH = "Death";

        private readonly int Death = Animator.StringToHash(DEATH);

        private IAttacker _attacker;
        private IMovement _movement;
        private Health _health;
        private ConsumerBehaviour _eater;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _attacker);
            TryGetComponent(out _movement);
            TryGetComponent(out _health);
            TryGetComponent(out _eater);

            _health.OnDied += OnDied;
        }

        private void OnDestroy()
        {
            _health.OnDied -= OnDied;
        }

        private void Update()
        {
            if (_attacker != null)
            {
                Animator.SetBool(IS_ATTACKING, _attacker.IsAttacking);
            }

            Animator.SetBool(IS_WALKING, _movement.IsWalking);
            Animator.SetBool(IS_RUNNING, _movement.IsRunning);
            Animator.SetBool(IS_EATING, _eater.IsEating);
        }

        private void OnDied()
        {
            Animator.CrossFade(DEATH, 0, 0);
        }
    }
}
