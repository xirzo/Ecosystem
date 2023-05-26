using UnityEngine;
namespace Game.Interaction
{
    public interface IRaycastInteractor : ILayerInteractor
    {
        public float InteractionDistance { get; }
    }
}
