using System;

namespace Game.Stats
{
    public interface IIncreaser
    {
        public event Action<Stat> OnIncrease;
        public float IncreaseValue { get; }
        public void Increase(Stat target);
    }
}
