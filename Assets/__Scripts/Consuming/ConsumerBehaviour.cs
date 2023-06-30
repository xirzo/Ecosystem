using System;
using System.Collections;
using Game.Interaction.Consume;
using UnityEngine;

namespace Game.Consuming
{
    public class ConsumerBehaviour : MonoBehaviour, IConsumer
    {
        public event Action OnEat;
        public event Action OnEaten;
        public bool IsEating => _isEating;

        [SerializeField, Min(0)] private float _eatingLength = 1f;

        private bool _isEating;

        public void Eat(Consumable consumable)
        {
            StartCoroutine(EatingCoroutine());
        }

        private IEnumerator EatingCoroutine()
        {
            OnEat?.Invoke();
            _isEating = true;

            yield return new WaitForSeconds(_eatingLength);

            _isEating = false;
            OnEaten?.Invoke();
        }
    }
}
