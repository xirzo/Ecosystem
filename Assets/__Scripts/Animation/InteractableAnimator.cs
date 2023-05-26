using Game.Interaction;
using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(InteractableBehavior))]
    public class InteractableAnimator : AnimatorBehavior
    {
        private InteractableBehavior _interactable;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _interactable);
        }

        private void Start()
        {
            _interactable.OnGotInteracted += OnInteracted;
        }

        private void OnDestroy()
        {
            _interactable.OnGotInteracted -= OnInteracted;
        }

        private void OnInteracted(IInteractor interactr)
        {
            Animator.SetTrigger("Interacted");
        }
    }
}
