using Game.ScriptableObjects;

namespace Game.Interaction
{
    public class EntityInteractable : InteractableBehavior
    {
        public new EntityInteractableData Data => (EntityInteractableData)base.Data;

    }
}