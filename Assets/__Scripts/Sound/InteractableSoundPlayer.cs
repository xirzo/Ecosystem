using Game.Interaction;
using UnityEngine;

namespace Game.Sound
{
    [RequireComponent(typeof(InteractableBehavior))]
    public class InteractableSoundPlayer : SoundPlayer
    {
        [SerializeField] private AudioClip _interactSound;
        [Space]
        [SerializeField, Min(0)] private float _delay = 0f;
        [SerializeField] private bool _loop;

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

        private void OnInteracted(IInteractor interactor)
        {
            Play(_interactSound, _delay, _loop);
        }
    }
}
