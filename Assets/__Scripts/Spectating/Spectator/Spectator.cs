using System;
using UnityEngine;

namespace Game.Spectating
{
    public class Spectator : MonoBehaviour, ISpectator
    {
        public event Action<bool> OnIsSpectatingChanged;
        public bool IsSpectating => _isSpectating;

        private bool _isSpectating;
        private Transform _parent;
        private Transform _defaultParent;

        protected virtual void Awake()
        {
            _defaultParent = transform.parent;
        }

        public void Spectate(ISpectatorable spectatorable)
        {
            GetParented(spectatorable.SpectatorHolder);
            _isSpectating = true;


            OnIsSpectatingChanged?.Invoke(_isSpectating);
        }

        public void Unspectate()
        {
            ClearParent();
            _isSpectating = false;
            OnIsSpectatingChanged?.Invoke(_isSpectating);
        }

        private void GetParented(Transform parent)
        {
            _parent = parent;

            transform.position = _parent.position;
            transform.rotation = _parent.rotation;

            transform.SetParent(_parent);
        }

        private void ClearParent()
        {
            transform.parent = _defaultParent;
            _parent = transform.parent;
        }
    }
}
