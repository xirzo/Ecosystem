using UnityEngine;

namespace Game.Spectating
{
    public class Spectatorable : MonoBehaviour, ISpectatorable
    {
        public Transform Body => transform;
        public Transform SpectatorHolder => _spectatorHolder;

        [SerializeField] private Transform _spectatorHolder;

    }
}
