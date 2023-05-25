using UnityEngine;

namespace Game.Orientations
{
    public abstract class Orientation : MonoBehaviour
    {
        public Transform ForwardPoint => _forwardPoint;
        public Transform OrientationObject => _orientation;
        public float RaycastDistance => _raycastDistance;
        public LayerMask RaycastLayers => _raycastLayers;

        [SerializeField] private Transform _orientation;
        [Space]
        [SerializeField, Min(0)] private float _raycastDistance = 2f;
        [SerializeField] private LayerMask _raycastLayers;
        [Space]
        [SerializeField] private Transform _forwardPoint;

        protected virtual void Update()
        {
            SetForwardPointPosition();
        }

        public bool TryToGetForwardCollider(out Collider collider)
        {
            if (Physics.Raycast(OrientationObject.transform.position, OrientationObject.transform.forward, out RaycastHit hit, RaycastDistance, RaycastLayers, QueryTriggerInteraction.Ignore))
            {
                collider = hit.collider;
                return true;
            }

            collider = null;
            return false;
        }

        public abstract Vector3 GetForwardPoint(float maxDistance = 100);
        public abstract Vector3 GetForwardDirection();
        private void SetForwardPointPosition()
        {
            Vector3 forwardPoint = GetForwardPoint(_raycastDistance);
            _forwardPoint.transform.position = forwardPoint;
        }
    }
}
