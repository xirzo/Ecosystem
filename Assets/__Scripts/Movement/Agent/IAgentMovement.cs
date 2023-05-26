using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Movement
{
    public interface IAgentMovement : IMovement
    {
        public bool IsCloseToDestination { get; }
        public float DistanceToDestination { get; }
        public float StoppingDistance { get; }
        public float RunStoppingDistance { get; }

        public void SetDestination(Vector3 destination);
        public void ResetDestination();
    }
}
