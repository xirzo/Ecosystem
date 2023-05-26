using Game.Interaction;
using Game.Orientations;
using UnityEngine;

namespace Game.UI
{
    public class InteractableNameDisplayer : TextDisplayer
    {
        [SerializeField] private RaycastInteractor _interactor;
        [SerializeField] private Orientation _orientation;

        private void Update()
        {
            if (_orientation.TryToGetForwardCollider(out Collider collider))
            {
                if ((_interactor.InteractableLayer & 1 << collider.gameObject.layer) == 1 << collider.gameObject.layer)
                {
                    if (collider.attachedRigidbody.gameObject.TryGetComponent(out InteractableBehavior interactable))
                    {
                        SetText(interactable.Data.Name);
                        return;
                    }
                }
            }

            SetText(null);
        }
    }
}
