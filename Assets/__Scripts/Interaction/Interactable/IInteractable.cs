using System;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Interaction
{
    public interface IInteractable
    {
        public event Action<IInteractor> OnGotInteracted;
        public InteractableData Data { get; }
        public GameObject Self { get; }
        public void GetInteracted(IInteractor interactor);
    }
}
