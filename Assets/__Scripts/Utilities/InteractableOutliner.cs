using Game.Interaction;
using Game.Orientations;
using UnityEngine;

namespace Game.Utilities
{
    [RequireComponent(typeof(Orientation))]
    [RequireComponent(typeof(RaycastInteractor))]
    public class InteractableOutliner : MonoBehaviour
    {
        [SerializeField, Range(0, 50)] private float _outlineWidth = 5f;
        [SerializeField] private Color _outlineColor = Color.white;
        [SerializeField] private Outline.Mode _outlineMode = Outline.Mode.OutlineVisible;

        private RaycastInteractor _interactor;
        private Orientation _orientation;

        private Outliner _currentOutliner;

        private void Awake()
        {
            TryGetComponent(out _interactor);
            TryGetComponent(out _orientation);
        }

        private void Update()
        {
            if (_orientation.TryToGetForwardCollider(out Collider collider))
            {
                if ((_interactor.InteractableLayer & 1 << collider.gameObject.layer) == 1 << collider.gameObject.layer)
                {
                    if (collider.gameObject.TryGetComponent(out Outliner outline))
                    {
                        if (_currentOutliner == null)
                        {
                            SetOutline(outline);
                            EnableOutline(true);
                            return;
                        }

                        if (_currentOutliner != outline)
                        {
                            EnableOutline(false);
                            ClearOutliner();

                            SetOutline(outline);
                            EnableOutline(true);
                            return;
                        }

                        return;
                    }

                }
            }


            if (_currentOutliner != null)
            {
                EnableOutline(false);
                ClearOutliner();
            }
        }

        private void EnableOutline(bool condition)
        {
            _currentOutliner.SetOutlineEnabled(condition);
        }

        private void SetOutline(Outliner outliner)
        {
            _currentOutliner = outliner;
            _currentOutliner.UpdateOutline(_outlineWidth, _outlineColor, _outlineMode);
        }

        private void ClearOutliner()
        {
            _currentOutliner = null;
        }
    }
}
