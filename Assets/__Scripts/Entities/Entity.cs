using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        public Gender Gender => _gender;

        private Gender _gender;

        private void Awake()
        {
            SetRandomGender();
        }

        private void SetRandomGender()
        {
            int index = Random.Range(0, 2);
            _gender = (Gender)index;
        }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}
