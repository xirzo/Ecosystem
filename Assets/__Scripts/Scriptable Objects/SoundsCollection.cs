using System.Collections.Generic;
using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Sound Collection", menuName = "Data/Sounds/Sounds Collection")]
    public class SoundsCollection : ScriptableObject
    {
        public List<AudioClip> Sounds => _sounds;

        [SerializeField] private List<AudioClip> _sounds = new List<AudioClip>();
    }
}
