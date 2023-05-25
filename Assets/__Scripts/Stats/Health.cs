using System;
using UnityEngine;

namespace Game.Stats
{
    public class Health : Stat
    {
        public event Action OnDied;

        private void Awake()
        {
            OnStatDecreased += OnHealthDecreased;
        }

        private void OnDestroy()
        {
            OnStatDecreased -= OnHealthDecreased;
        }

        private void Die()
        {
            gameObject.SetActive(false);
            OnDied?.Invoke();
        }

        private void OnHealthDecreased(float value)
        {
            if (Value == 0)
            {
                Die();
            }
        }
    }
}
