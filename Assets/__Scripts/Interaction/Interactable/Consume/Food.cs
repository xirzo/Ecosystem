using System.Collections;
using UnityEngine;
using Game.Stats;
using Game.Consuming;

namespace Game.Interaction.Consume
{
    public class Food : Consumable
    {
        [SerializeField, Min(0)] private float _disappearSpeed = 3f;

        private IConsumer _consumer;

        protected override void GetConsumed(IInteractor interactor)
        {
            if (interactor.Self.TryGetComponent(out Satiety satiety))
            {
                Increase(satiety);
            }

            if (interactor.Self.TryGetComponent(out IConsumer consumer))
            {
                _consumer = consumer;
                _consumer.OnEaten += () => StartCoroutine(DisappearCoroutine());
            }
        }

        private void OnDestroy()
        {
            if (_consumer != null)
            {
                _consumer.OnEaten -= () => StartCoroutine(DisappearCoroutine());
                _consumer = null;
            }
        }

        private IEnumerator DisappearCoroutine()
        {
            float step = _disappearSpeed * Time.fixedDeltaTime;
            float time = 0;

            Vector3 startScale = Vector3.one;
            Vector3 endScale = Vector3.zero;

            while (time <= 1.0f)
            {
                time += step;

                transform.localScale = Vector3.Lerp(startScale, endScale, time);

                yield return null;
            }

            transform.localScale = endScale;

            gameObject.SetActive(false);

            transform.localScale = startScale;
        }
    }
}
