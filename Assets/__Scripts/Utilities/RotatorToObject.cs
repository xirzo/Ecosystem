using UnityEngine;

namespace Game.Utilities
{
    public class RotatorToObject : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void Update()
        {
            RotateToCamera();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void RotateToCamera()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _target.position);
        }
    }
}
