using UnityEngine;

namespace Game.Utilities
{
    public class Outliner : MonoBehaviour
    {
        [SerializeField] private Outline _outline;

        private void Awake()
        {
            if (_outline == null)
            {
                TryGetComponent(out _outline);
            }
        }

        public void UpdateOutline(float width, Color color, Outline.Mode outlineMode)
        {
            _outline.OutlineWidth = width;
            _outline.OutlineColor = color;
            _outline.OutlineMode = outlineMode;
        }

        public void SetOutlineEnabled(bool condition)
        {
            _outline.enabled= condition;
        }
    }
}
