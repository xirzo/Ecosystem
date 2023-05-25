using UnityEngine;
using Game.Interfaces;

namespace Game.Animation
{
    [RequireComponent(typeof(IToggleable))]
    public class ToggleableAnimator : AnimatorController
    {
        private IToggleable _toggleable;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _toggleable);

            _toggleable.OnToggled += OnToggled;
        }
        private void OnDestroy()
        {
            _toggleable.OnToggled -= OnToggled;
        }

        private void OnToggled(bool value)
        {
            Animator.SetBool("IsToggled", value);
        }

    }
}
