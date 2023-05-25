using Game.Stats;
using UnityEngine;

namespace Game.UI
{
    public class StatBarDisplayer : BarDisplayer
    {
        [SerializeField] private Stat _stat;

        private void Start()
        {
            _targetAmount = _stat.Value;
            _maxAmount = _stat.MaxValue;

            _stat.OnStatChanged += UpdateAmount;
            UpdateAmount(_targetAmount);
        }

        private void OnDestroy()
        {
            _stat.OnStatChanged -= UpdateAmount;
        }
    }
}
