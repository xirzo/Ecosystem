using System;
using UnityEngine;

namespace Game.Interaction
{
    public class InteractorBehaviour : MonoBehaviour, IInteractor
    {
        public event Action<IInteractable> OnInteracted;
        public GameObject Self => gameObject;
        public void Interact(IInteractable target)
        {
            target.GetInteracted(this);
            OnInteracted?.Invoke(target);
        }
    }
}
