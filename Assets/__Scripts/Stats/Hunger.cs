using System;
using Game.Stats.Substraction;
using UnityEngine;

namespace Game.Stats
{
    public class Hunger : Stat, IDecreaser
    {
        public event Action<Stat> OnDamaged;
        public float DecreaseValue => _decreasevalue;

        [SerializeField, Min(0)] private float _decreasevalue = 0.5f;

        private void Update()
        {
            Decrease(this);
        }

        public void Decrease(Stat target)
        {
            target.Decrease(_decreasevalue);
            OnDamaged?.Invoke(this);
        }
    }
}
