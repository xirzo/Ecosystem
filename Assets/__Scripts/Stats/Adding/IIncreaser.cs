using System;

namespace Game.Stats
{
    public interface IIncreaser
    {
        public event Action<Health> OnIncrease;
        public float Value { get; }
        public void Increase(Health target);
    }
}
