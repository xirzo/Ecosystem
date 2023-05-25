using UnityEngine;

namespace Game.Sound
{
    public class AmbientSoundPlayer : SoundPlayer
    {
        [SerializeField] private AudioClip _ambience;
        [Space]
        [SerializeField, Min(0)] private float _delay = 0f;
        [SerializeField] private bool _loop;

        private void Start()
        {
            Play(_ambience, _delay, _loop);
        }
    }
}
