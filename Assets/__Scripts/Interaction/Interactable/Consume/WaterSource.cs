using Game.Stats;

namespace Game.Interaction.Consume
{
    public class WaterSource : Consumable
    {
        protected override void GetConsumed(IInteractor interactor)
        {
            if (interactor.Self.TryGetComponent(out Thirst thirst))
            {
                Increase(thirst);
            }
        }
    }
}
