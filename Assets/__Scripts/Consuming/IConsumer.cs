using System;
using Game.Interaction.Consume;

namespace Game.Consuming
{
    public interface IConsumer
    {
        public event Action OnEat;
        public event Action OnEaten;
        public bool IsEating { get; }
        public void Eat(Consumable consumable);
    }
}
