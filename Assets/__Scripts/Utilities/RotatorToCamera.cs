using UnityEngine;

namespace Game.Utilities
{
    public class RotatorToCamera : RotatorToObject
    {
        private void Awake()
        {
            SetTarget(Camera.main.transform);
        }
    }
}
