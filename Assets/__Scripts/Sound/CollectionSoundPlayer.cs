using System;
using Game.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Sound
{
    public class CollectionSoundPlayer : SoundPlayer
    {
        [SerializeField] private SoundsCollection _colletion;

        protected AudioClip GetRandomSound()
        {
            int index = Random.Range(0, _colletion.Sounds.Count - 1);
            return _colletion.Sounds[index];
        }

        protected AudioClip GetSoundByIndex(int index)
        {
            if (index > _colletion.Sounds.Count && index < 0)
                throw new Exception($"There is no sound in collection with index: {index}");

            return _colletion.Sounds[index];
        }
    }
}
