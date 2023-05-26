using UnityEngine;
namespace Game.Interaction
{
    public interface ILayerInteractor : IInteractor
    {
        public LayerMask InteractableLayer { get; }
    }
}
