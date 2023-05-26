using System;
using System.Collections.Generic;

namespace Game.Interaction
{
    public interface IRadiusInteractor : ILayerInteractor
    {
        public float InteractionRadius { get; }
        public List<IInteractable> InteractablesInRadius { get; }
        public IInteractable ClosesetInteractableInRadius { get; }
        public bool TryGetClosestAvailableInteractable(Type interactableType, out IInteractable interactable);
    }
}
