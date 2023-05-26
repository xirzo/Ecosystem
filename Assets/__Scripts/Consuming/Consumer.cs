using System.Collections;
using Game.Interaction.Consume;
using UnityEngine;

namespace Game.Consuming
{
    public class Consumer : MonoBehaviour
    {
        public bool IsEating => _isEating;

        [SerializeField, Min(0)] private float _eatingLength = 1f;

        private bool _isEating;

        public void Eat(Consumable consumable)
        {
            StartCoroutine(EatingCoroutine());
        }

        private IEnumerator EatingCoroutine()
        {
            _isEating = true;

            yield return new WaitForSeconds(_eatingLength);

            _isEating = false;
        }
    }
}
