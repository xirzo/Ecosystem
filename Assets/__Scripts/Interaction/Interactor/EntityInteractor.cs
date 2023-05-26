using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Interaction
{
    public class EntityInteractor : InteractorBehavior
    {
        public float InteractionRadius => _interactionRadius;
        public List<IInteractable> AvailableInteractables { get; private set; }
        public IInteractable ClosesetAvailableInteractable { get; private set; }

        [SerializeField, Min(0)] private float _interactionRadius = 10f;
        [Space]
        [SerializeField] private LayerMask _interactableLayers;

        private void Update()
        {
            ClosesetAvailableInteractable = GetClosestAvailableInteractable();
        }
        public bool TryGetClosestAvailableInteractable(Type type, out IInteractable interactable)
        {
            if (AvailableInteractables.Count > 0)
            {
                IInteractable closestInteractable = null;
                float previousLowestDistance = float.MaxValue;

                foreach (var availableInteractable in AvailableInteractables)
                {
                    if (availableInteractable.Self.TryGetComponent(type, out Component component))
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
            Collider[] colliders = Physics.OverlapSphere(transform.position, _interactionRadius, _interactableLayers, QueryTriggerInteraction.Ignore);
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

                AvailableInteractables = availableInteractables;
                return true;
            }

            AvailableInteractables = availableInteractables;
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
