using System;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Interaction
{
    [RequireComponent(typeof(Rigidbody))]
    public class InteractableBehaviour : MonoBehaviour, IInteractable
    {
        public event Action<IInteractor> OnGotInteracted;
        public InteractableData Data => _data;
        public GameObject Self => gameObject;

        [SerializeField] protected InteractableData _data;

        public void SetData(InteractableData data)
        {
            _data = data;
        }

        public virtual void GetInteracted(IInteractor interactor)
        {
            OnGotInteracted?.Invoke(interactor);
        }
    }
}