using System;
using UnityEngine;

namespace Game.Interaction
{
    public interface IInteractor
    {
        public event Action<IInteractable> OnInteracted;
        public GameObject Self { get; }
        public void Interact(IInteractable target);
    }
}
