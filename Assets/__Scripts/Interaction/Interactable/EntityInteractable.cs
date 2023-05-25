using Game.ScriptableObjects;

namespace Game.Interaction
{
    public class EntityInteractable : Interactable
    {
        public new EntityInteractableData Data => (EntityInteractableData)base.Data;

    }
}