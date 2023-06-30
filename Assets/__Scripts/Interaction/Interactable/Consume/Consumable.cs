using System;
using Game.ScriptableObjects;
using Game.Stats;

namespace Game.Interaction.Consume
{
    public abstract class Consumable : InteractableBehaviour, IIncreaser
    {
        public event Action<Stat> OnIncrease;
        public new ConsumableData Data => (ConsumableData)base.Data;
        public float IncreaseValue => Data.StatIncreaseValue;

        public override void GetInteracted(IInteractor interactor)
        {
            GetConsumed(interactor);

            base.GetInteracted(interactor);
        }

        public void Increase(Stat target)
        {
            target.Increase(Data.StatIncreaseValue);
            OnIncrease?.Invoke(target);
        }

        protected abstract void GetConsumed(IInteractor interactor);
    }
}
