using Game.Interaction;
using Game.Interaction.Consume;
using UnityEngine;

namespace Game.Consuming
{
    [RequireComponent(typeof(IInteractor))]
    public class EntityConsumer : ConsumerBehaviour
    {
        private IInteractor _interactor;

        private void Awake()
        {
            TryGetComponent(out _interactor);

            _interactor.OnInteracted += OnInteracted;
        }

        private void OnDestroy()
        {
            _interactor.OnInteracted -= OnInteracted;
        }

        private void OnInteracted(IInteractable interactable)
        {
            if (interactable.Self.TryGetComponent(out Consumable consumable))
            {
                Eat(consumable);
            }
        }
    }
}
