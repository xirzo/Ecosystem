using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public abstract class BarDisplayer : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private Color _fillColor;
        [SerializeField, Range(0, 10f)] private float _reduceSpeed = 1f;

        protected float _targetAmount;
        protected float _maxAmount;

        protected virtual void Awake()
        {
            _fill.color = _fillColor;
        }

        private void OnValidate()
        {
            _fill.color = _fillColor;
        }

        private void Update()
        {
            ApplyAnimation();
        }

        private void ApplyAnimation()
        {
            _fill.fillAmount = Mathf.MoveTowards(_fill.fillAmount, _targetAmount, _reduceSpeed * Time.deltaTime);
        }

        protected void UpdateAmount(float amount)
        {
            _targetAmount = amount / _maxAmount;
        }
    }
}
