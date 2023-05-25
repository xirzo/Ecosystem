using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Spectating
{
    public interface ISpectatorable
    {
        public Transform Body { get; }
        public Transform SpectatorHolder { get; }
    }
}
