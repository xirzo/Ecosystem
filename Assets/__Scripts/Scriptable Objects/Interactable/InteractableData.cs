using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Interactable", menuName = "Data/Interactables/Interactable", order = 0)]
    public class InteractableData : ScriptableObject
    {
        public string Name => _name;

        [SerializeField] private string _name;
    }
}
