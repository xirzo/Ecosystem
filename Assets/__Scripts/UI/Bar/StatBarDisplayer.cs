using Game.Stats;
using UnityEngine;

namespace Game.UI
{
    public class StatBarDisplayer : BarDisplayer
    {
        [SerializeField] private Stat _stat;

        private void Start()
        {
            _targetAmount = _stat.StatValue;
            _maxAmount = _stat.MaxStatValue;

            _stat.OnStatChanged += UpdateAmount;
            UpdateAmount(_targetAmount);
        }

        private void OnDestroy()
        {
            _stat.OnStatChanged -= UpdateAmount;
        }
    }
}
