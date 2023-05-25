using UnityEngine;

namespace Game.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;
        protected virtual void Awake()
        {
            TryGetComponent(out _audioSource);
        }

        public void Play(AudioClip clip, float delay = 0, bool loop = false)
        {
            _audioSource.clip = clip;
            _audioSource.loop = loop;


            if (delay > 0)
            {
                _audioSource.PlayDelayed(delay);
                return;
            }

            _audioSource.Play();
        }

        public void PlayOneShot(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }

        public void Pause()
        {
            _audioSource.Pause();
        }

        public void Stop()
        {
            _audioSource.Stop();
            _audioSource.clip = null;
        }
    }
}
