using System;

namespace Game.Stats.Adding
{
    public interface IIncreaser
    {
        public event Action<Health> OnHealed;
        public float Value { get; }
        public void TryToHeal(Health target);
    }
}
