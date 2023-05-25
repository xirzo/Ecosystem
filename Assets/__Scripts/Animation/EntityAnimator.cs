using Game.Movement;
using Game.Stats;
using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(IMoveable))]
    [RequireComponent(typeof(Health))]
    public class EntityAnimator : AnimatorController
    {
        private const string IS_WALKING = "isWalking";
        private const string IS_STANDING = "isStanding";
        private const string DIED = "Died";
        private const string IS_RUNNING = "isRunning";
        private const string IS_ATTACKING = "isAttacking";

        private IMoveable _movement;
        private Health _health;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _movement);
            TryGetComponent(out _health);

            _health.OnDied += OnDied;
        }

        private void OnDestroy()
        {
            _health.OnDied -= OnDied;
        }

        private void Update()
        {
            Animator.SetBool(IS_WALKING, _movement.IsWalking);
            Animator.SetBool(IS_RUNNING, _movement.IsRunning);
        }

        private void OnDied()
        {
            Animator.SetTrigger(DIED);
        }
    }
}
