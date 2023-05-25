using System;

namespace Game.Stats
{
    public interface IDecreaser
    {
        public event Action<Stat> OnDecreased;
        public float DecreaseValue { get; }
        public void Decrease(Stat target);
    }
}
