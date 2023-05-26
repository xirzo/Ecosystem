using System.Collections;
using Game.Interaction;
using Game.Interaction.Consume;
using UnityEngine;

namespace Game.Eating
{
    [RequireComponent(typeof(IInteractor))]
    public class Eater : MonoBehaviour
    {
        public bool IsEating => _isEating;

        [SerializeField, Min(0)] private float _eatingLength = 1f;

        private IInteractor _interactor;

        private bool _isEating;

        private void Awake()
        {
            TryGetComponent(out _interactor);

            _interactor.OnInteracted += OnInteracted;
        }

        private void OnDestroy()
        {
            _interactor.OnInteracted -= OnInteracted;
        }

        public void Eat(Consumable consumable)
        {
            StartCoroutine(EatingCoroutine());
        }

        private void OnInteracted(IInteractable interactable)
        {
            if (interactable.Self.TryGetComponent(out Consumable consumable))
            {
                Eat(consumable);
            }
        }

        private IEnumerator EatingCoroutine()
        {
            _isEating = true;

            yield return new WaitForSeconds(_eatingLength);

            _isEating = false;
        }
    }
}
