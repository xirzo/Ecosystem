using Game.Orientations;
using UnityEngine;

namespace Game.Interaction
{
    [RequireComponent(typeof(Orientation))]
    public abstract class RaycastInteractor : InteractorBehavior, IRaycastInteractor
    {
        public LayerMask InteractableLayer => _interactableLayer;
        public float InteractionDistance => _orientation.RaycastDistance;

        [SerializeField] private LayerMask _interactableLayer;

        private Orientation _orientation;

        protected virtual void Awake()
        {
            TryGetComponent(out _orientation);
        }

        protected void TryToInteract()
        {
            if (_orientation.TryToGetForwardCollider(out Collider collider) == true)
            {
                if ((_interactableLayer & 1 << collider.gameObject.layer) == 1 << collider.gameObject.layer)
                {
                    if (collider.attachedRigidbody.TryGetComponent(out InteractableBehavior target))
                    {
                        Interact(target);
                    }
                }
            }

        }
    }
}
