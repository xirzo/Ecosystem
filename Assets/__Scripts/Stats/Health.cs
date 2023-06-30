using System;
using System.Collections.Generic;
using Game.Interaction;
using Game.Interaction.Consume;
using Game.Movement;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Stats
{
    public class Health : Stat
    {
        public event Action OnDied;

        public bool IsDead { get; private set; }

        [SerializeField] private ConsumableData _deathConsumableData;

        private List<MonoBehaviour> _componentsToTurnOffWhenDied = new List<MonoBehaviour>();

        private EntityInteractable _entityInteractable;

        private void Awake()
        {
            GetComponentsToTurnOff();

            TryGetComponent(out _entityInteractable); 

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

            Destroy(_entityInteractable);
            Food food = gameObject.AddComponent<Food>();
            food.SetData(_deathConsumableData);

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
