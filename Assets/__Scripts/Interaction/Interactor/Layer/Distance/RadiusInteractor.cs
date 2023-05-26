using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interaction
{
    public abstract class RadiusInteractor : InteractorBehavior, IRadiusInteractor
    {
        public LayerMask InteractableLayer => _interactableLayer;
        public float InteractionRadius => _interactionRadius;
        public List<IInteractable> InteractablesInRadius => _interactablesInRadius;
        public IInteractable ClosesetInteractableInRadius => _closesetInteractableInRadius;


        [SerializeField, Min(0)] private float _interactionRadius = 10f;
        [Space]
        [SerializeField] private LayerMask _interactableLayer;

        private List<IInteractable> _interactablesInRadius;
        private IInteractable _closesetInteractableInRadius;

        private void Update()
        {
            _closesetInteractableInRadius = GetClosestAvailableInteractable();
        }

        public bool TryGetClosestAvailableInteractable(Type interactableType, out IInteractable interactable)
        {
            if (_interactablesInRadius.Count > 0)
            {
                IInteractable closestInteractable = null;
                float previousLowestDistance = float.MaxValue;

                foreach (var availableInteractable in _interactablesInRadius)
                {
                    if (availableInteractable.Self.TryGetComponent(interactableType, out Component component))
                    {
                        float distance = Vector3.Distance(transform.position, availableInteractable.Self.transform.position);

                        if (distance < previousLowestDistance)
                        {
                            closestInteractable = availableInteractable;
                            previousLowestDistance = distance;
                        }
                    }
                }

                if (closestInteractable != null)
                {
                    interactable = closestInteractable;
                    return true;
                }
            }

            interactable = null;
            return false;
        }

        private bool TryGetAvailableInteractable(out List<IInteractable> availableInteractables)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _interactionRadius, _interactableLayer, QueryTriggerInteraction.Ignore);
            availableInteractables = new List<IInteractable>(colliders.Length);

            if (colliders.Length > 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].attachedRigidbody != null)
                    {
                        if (colliders[i].attachedRigidbody.TryGetComponent(out IInteractable interactable) == true)
                        {
                            availableInteractables.Add(interactable);
                        }
                    }
                }

                _interactablesInRadius = availableInteractables;
                return true;
            }

            _interactablesInRadius = availableInteractables;
            return false;
        }

        private IInteractable GetClosestAvailableInteractable()
        {
            if (TryGetAvailableInteractable(out List<IInteractable> availableInteractables) == true)
            {
                if (availableInteractables.Count > 0)
                {
                    IInteractable closestInteractable = availableInteractables[0];

                    float previousLowestDistance = Vector3.Distance(transform.position, closestInteractable.Self.transform.position);

                    foreach (IInteractable interactable in availableInteractables)
                    {
                        float distance = Vector3.Distance(transform.position, interactable.Self.transform.position);

                        if (distance < previousLowestDistance)
                        {
                            closestInteractable = interactable;
                            previousLowestDistance = distance;
                        }
                    }

                    return closestInteractable;
                }
            }

            return null;
        }
    }
}
