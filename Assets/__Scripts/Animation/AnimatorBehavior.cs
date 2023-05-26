using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorBehavior : MonoBehaviour
    {
        public Animator Animator => _animator;

        [SerializeField] private bool _isEnabledByDefault = true;

        private Animator _animator;
        protected virtual void Awake()
        {
            TryGetComponent(out _animator);

            if (_isEnabledByDefault == false)
            {
                _animator.enabled = false;
            }
        }
    }
}
