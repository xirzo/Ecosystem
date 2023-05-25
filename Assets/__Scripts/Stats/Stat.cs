using System;
using UnityEngine;

namespace Game.Stats
{

    public abstract class Stat : MonoBehaviour
    {
        public event Action<float> OnStatChanged;
        public event Action<float> OnStatIncreased;
        public event Action<float> OnStatDecreased;

        public float Value => _stat;
        public float MaxValue => _maxStat;

        [SerializeField, Range(0, 1000f)] private float _stat = 100;
        [SerializeField, Range(0, 1000f)] private float _maxStat = 100;

        public void Increase(float value)
        {
            if (_stat + value >= _maxStat)
            {
                _stat = _maxStat;

                OnStatIncreased?.Invoke(_stat);
                OnStatChanged?.Invoke(_stat);

                return;
            }

            _stat += value;

            OnStatIncreased?.Invoke(_stat);
            OnStatChanged?.Invoke(_stat);
        }

        public void Decrease(float value)
        {
            if (_stat - value <= 0)
            {
                _stat = 0;

                OnStatDecreased?.Invoke(_stat);
                OnStatChanged?.Invoke(_stat);

                return;
            }

            _stat -= value;

            OnStatDecreased?.Invoke(_stat);
            OnStatChanged?.Invoke(_stat);
        }

        public void ResetToZero()
        {
            _stat = 0;

            OnStatDecreased?.Invoke(_stat);
            OnStatChanged?.Invoke(_stat);
        }

        private void OnValidate()
        {
            OnStatChanged?.Invoke(_stat);
        }
    }
}
