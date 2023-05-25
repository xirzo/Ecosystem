using System;

namespace Game.Stats.Substraction
{
    public interface IDecreaser
    {
        public event Action<Stat> OnDamaged;
        public float DecreaseValue { get; }
        public void Decrease(Stat target);
    }
}
