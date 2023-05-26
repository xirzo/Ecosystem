using Game.Consuming;
using Game.Movement;
using Game.Stats;
using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(IMoveable))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Consumer))]
    public class EntityAnimator : AnimatorBehavior
    {
        private const string IS_WALKING = "isWalking";
        private const string IS_STANDING = "isStanding";
        private const string DIED = "Died";
        private const string IS_RUNNING = "isRunning";
        private const string IS_ATTACKING = "isAttacking";
        private const string IS_EATING = "isEating";

        private IMoveable _movement;
        private Health _health;
        private Consumer _eater;

        protected override void Awake()
        {
            base.Awake();

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
            Animator.SetBool(IS_WALKING, _movement.IsWalking);
            Animator.SetBool(IS_RUNNING, _movement.IsRunning);
            Animator.SetBool(IS_EATING, _eater.IsEating);
        } 

        private void OnDied()
        {
            Animator.SetTrigger(DIED);
        }
    }
}
