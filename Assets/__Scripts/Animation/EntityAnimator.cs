using Game.Interaction;
using Game.Movement;
using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(IMoveable))]
    public class EntityAnimator : AnimatorController
    {
        private IMoveable _movement;

        private const string IS_WALKING = "isWalking";
        private const string IS_STANDING = "isStanding";
        private const string IS_DEAD = "isDead";
        private const string IS_RUNNING = "isRunning";
        private const string IS_ATTACKING = "isAttacking";

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _movement);
        }

        private void Start()
        {

        }

        private void OnDestroy()
        {

        }

        private void Update()
        {
            Animator.SetBool(IS_WALKING, _movement.IsWalking);
            Animator.SetBool(IS_RUNNING, _movement.IsRunning);
        }

        private void OnInteracted(IInteractor interactr)
        {
            Animator.SetTrigger("Interacted");
        }
    }
}
