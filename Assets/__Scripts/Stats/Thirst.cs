using UnityEngine;

namespace Game.Stats
{
    [RequireComponent(typeof(Health))]
    public class Thirst : Stat
    {
        public bool IsThirsty => Value < MaxValue;

        [SerializeField, Min(0)] private float _thirstDecreaseValue = 0.01f;
        [SerializeField, Min(0)] private float _healthDecreaseValue = 0.01f;

        private Health _health;
        private bool _hasHealth;

        private void Awake()
        {
            if (TryGetComponent(out _health) == true)
            {
                _hasHealth = true;
            }
        }

        private void Update()
        {
            if (_health.IsDead == true)
            {
                ResetToZero();
                return;
            }

            Decrease(_thirstDecreaseValue);

            if (_hasHealth == true)
            {
                if (Value <= 0)
                {
                    _health.Decrease(_healthDecreaseValue);
                }
            }
        }
    }
}
