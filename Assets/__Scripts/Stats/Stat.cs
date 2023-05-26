using System;
using UnityEngine;

namespace Game.Stats
{

    public abstract class Stat : MonoBehaviour
    {
        public event Action<float> OnStatChanged;
        public event Action<float> OnStatIncreased;
        public event Action<float> OnStatDecreased;

        public float StatValue => _statValue;
        public float MaxStatValue => _maxStatValue;

        [SerializeField, Range(0, 1000f)] private float _statValue = 100;
        [SerializeField, Range(0, 1000f)] private float _maxStatValue = 100;

        public void Increase(float value)
        {
            if (_statValue + value >= _maxStatValue)
            {
                _statValue = _maxStatValue;

                OnStatIncreased?.Invoke(_statValue);
                OnStatChanged?.Invoke(_statValue);

                return;
            }

            _statValue += value;

            OnStatIncreased?.Invoke(_statValue);
            OnStatChanged?.Invoke(_statValue);
        }

        public void Decrease(float value)
        {
            if (_statValue - value <= 0)
            {
                _statValue = 0;

                OnStatDecreased?.Invoke(_statValue);
                OnStatChanged?.Invoke(_statValue);

                return;
            }

            _statValue -= value;

            OnStatDecreased?.Invoke(_statValue);
            OnStatChanged?.Invoke(_statValue);
        }

        public void ResetToZero()
        {
            _statValue = 0;

            OnStatDecreased?.Invoke(_statValue);
            OnStatChanged?.Invoke(_statValue);
        }

        private void OnValidate()
        {
            OnStatChanged?.Invoke(_statValue);
        }
    }
}
