using System.Collections;
using UnityEngine;
using Game.Stats;
using static UnityEditor.Progress;

namespace Game.Interaction.Consume
{
    public class Food : Consumable
    {
        [SerializeField, Min(0)] private float _disappearSpeed = 3f;

        protected override void GetConsumed(IInteractor interactor)
        {
            if (interactor.Self.TryGetComponent(out Satiety satiety))
            {
                Increase(satiety);
            }

            StartCoroutine(DisappearCoroutine());
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