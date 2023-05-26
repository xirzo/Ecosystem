using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Interactable", menuName = "Data/Interactables/Consumable", order = 0)]
    public class ConsumableData : InteractableData
    {
        public float StatIncreaseValue => _statIncreaseValue;

        [SerializeField, Min(0)] private float _statIncreaseValue = 50f;
    }
}
