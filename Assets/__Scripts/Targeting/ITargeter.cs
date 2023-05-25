using UnityEngine;

namespace Game.Targeting
{
    public interface ITargeter
    {
        public float TargetingRange { get; }
        public float TargetingAngle { get; }
        public LayerMask TargetLayer { get; }
        public LayerMask ObstacleLayer { get; }
        public Transform PreviousTarget { get; }
        public Transform Target { get; }
        public Collider Obstacle { get; }
        public float DistanceToTarget { get; }
        public bool CanSeeTarget { get; }
    }
}
