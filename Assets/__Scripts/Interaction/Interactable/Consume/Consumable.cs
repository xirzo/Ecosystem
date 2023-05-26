using System;
using Game.Interaction;
using Game.ScriptableObjects;
using Game.Stats;
using UnityEngine;

namespace Game.Interaction.Consume
{
    public abstract class Consumable : InteractableBehavior, IIncreaser
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
