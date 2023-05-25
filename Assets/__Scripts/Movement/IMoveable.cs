using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Movement
{
    public interface IMoveable
    {
        public bool IsWalking { get; }
        public bool IsRunning { get; }
    }
}
