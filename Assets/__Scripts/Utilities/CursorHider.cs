using UnityEngine;

namespace Game.Utilities
{
    public class CursorHider : MonoBehaviour
    {
        [SerializeField] private bool _visible;
        [SerializeField] private CursorLockMode _lockMode;

        private void Awake()
        {
            SetVisibility(_visible);
            SetLock(_lockMode);
        }

        private void OnValidate()
        {
            SetVisibility(_visible);
            SetLock(_lockMode);
        }

        public void SetVisibility(bool value)
        {
            Cursor.visible = value;
        }

        public void SetLock(CursorLockMode mode)
        {
            Cursor.lockState = mode;
        }
    }
}
