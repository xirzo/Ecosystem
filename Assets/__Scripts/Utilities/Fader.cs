using System;
using Game.Animation;
using UnityEngine;

namespace Game.Utilities
{
    public class Fader : AnimatorController
    {
        public bool IsFading { get; private set; }
        private const string FADER_PATH = "Fader";

        private const string FADER_ANIMATOR_BOOL = "Is Faded";

        public static Fader Instance
        {
            get
            {
                if (_instance == null)
                {
                    Fader prefab = Resources.Load<Fader>(FADER_PATH);
                    _instance = Instantiate(prefab);
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }

        private static Fader _instance;

        private Action _fadedInCallback;
        private Action _fadedOutCallback;

        public void FadeIn(Action fadedInCallback)
        {
            if (IsFading == true)
                return;

            IsFading = true;
            _fadedInCallback = fadedInCallback;
            Animator.SetBool(FADER_ANIMATOR_BOOL, true);
        }

        public void FadeOut(Action fadedOutCallback)
        {
            if (IsFading == true)
                return;

            IsFading = true;
            _fadedInCallback = fadedOutCallback;
            Animator.SetBool(FADER_ANIMATOR_BOOL, false);
        }

        private void Handle_FadeInAnimationOver()
        {
            _fadedInCallback?.Invoke();
            _fadedInCallback = null;
            IsFading = false;
        }

        private void Handle_FadeOutAnimationOver()
        {
            _fadedOutCallback?.Invoke();
            _fadedOutCallback = null;
            IsFading = false;
        }
    }
}
