using System;
using Game.Gendering;
using UnityEngine;

namespace Game.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        public event Action<Gender> OnGenderSet;

        public Gender Gender => _gender;

        private Gender _gender;

        public void SetGender(Gender newGender)
        {
            _gender = newGender;
            OnGenderSet?.Invoke(_gender);
        }
    }
}
