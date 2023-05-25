using Game.Interfaces;
using UnityEngine;

namespace Game.Sound
{
    [RequireComponent(typeof (IToggleable))]
    public class ToggleableSoundPlayer : SoundPlayer
    {
        [SerializeField] private AudioClip _toggledSound;
        [SerializeField] private AudioClip _untoggledSound;
        [Space]
        [SerializeField, Min(0)] private float _delay = 0f;
        [SerializeField] private bool _loop;

        private IToggleable _toggleable;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _toggleable);
        }

        private void Start()
        {
            _toggleable.OnToggled += OnToggled;
        }

        private void OnDestroy()
        {
            _toggleable.OnToggled -= OnToggled;
        }

        private void OnToggled(bool toggled)
        {
            if (toggled == true)
            {
                Play(_toggledSound, _delay, _loop);
                return;
            }

            Play(_untoggledSound, _delay, _loop);
        }
    }
}
