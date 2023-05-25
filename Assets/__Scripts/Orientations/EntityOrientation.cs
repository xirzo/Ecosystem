using System;
using UnityEngine;

namespace Game.Orientations
{
    public class EntityOrientation : Orientation
    {
        public override Vector3 GetForwardPoint(float maxDistance = 100)
        {
            Ray ray = GetForwardRay();

            RaycastHit hit;
            Vector3 targetPoint;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                targetPoint = hit.point;
                return targetPoint;
            }

            return ray.GetPoint(maxDistance);
        }

        public override Vector3 GetForwardDirection()
        {
            Ray ray = GetForwardRay();
            return ray.direction;
        }

        private Ray GetForwardRay()
        {
            return new Ray(OrientationObject.position, OrientationObject.forward);
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(OrientationObject.position, OrientationObject.forward * RaycastDistance);
            }
        }
    }
}
