using System;
using System.Collections.Generic;
using Game.Movement;
using UnityEngine;

namespace Game.Stats
{
    public class Health : Stat
    {
        public event Action OnDied;

        public bool IsDead { get; private set; }

        private List<MonoBehaviour> _componentsToTurnOffWhenDied = new List<MonoBehaviour>();

        private void Awake()
        {
            GetComponentsToTurnOff();

            OnStatDecreased += OnHealthDecreased;
        }


        private void OnDestroy()
        {
            OnStatDecreased -= OnHealthDecreased;
        }

        private void Die()
        {
            foreach (var component in _componentsToTurnOffWhenDied)
            {
                component.enabled = false;
            }

            IsDead = true;

            OnDied?.Invoke();
        }

        private void OnHealthDecreased(float value)
        {
            if (StatValue == 0)
            {
                Die();
            }
        }

        private void GetComponentsToTurnOff()
        {
            if (TryGetComponent(out EntityMovement movement))
            {
                _componentsToTurnOffWhenDied.Add(movement);
            }
        }
    }
}
