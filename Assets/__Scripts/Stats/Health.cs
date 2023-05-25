using UnityEngine;
using System;
using Game.StateMachines.Entity;
using System.Collections.Generic;
using Game.Movement;

namespace Game.Stats
{
    public class Health : Stat
    {
        public event Action OnDied;

        public bool IsDead { get; private set; }

        private List<MonoBehaviour> _componentsToTurnOffWhenDied = new List<MonoBehaviour>();
        private EntityStateMachine _stateMachine;

        private void Awake()
        {
            TryGetComponent(out _stateMachine);

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

            _stateMachine.SetState<EntityDead>();
            IsDead = true;

            OnDied?.Invoke();
        }

        private void OnHealthDecreased(float value)
        {
            if (Value == 0)
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
