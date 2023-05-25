using Game.Interaction;
using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(Interactable))]
    public class InteractableAnimator : AnimatorController
    {
        private Interactable _interactable;

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
