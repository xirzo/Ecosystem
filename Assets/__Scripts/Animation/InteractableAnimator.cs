using Game.Interaction;
using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(InteractableBehaviour))]
    public class InteractableAnimator : AnimatorBehavior
    {
        private InteractableBehaviour _interactable;

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
