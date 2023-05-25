using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Targeting
{
    public class AngleTargeter : MonoBehaviour, ITargeter
    {
        public Transform PreviousTarget => _previousTarget;
        public Transform Target => _target;
        public Collider Obstacle => _obstacle;
        public float TargetingRange => _targetingRange;
        public float TargetingAngle => _targetingAngle;
        public LayerMask TargetLayer => _targetLayer;
        public LayerMask ObstacleLayer => _obstacleLayer;
        public float DistanceToTarget => _distanceToTarget;
        public bool CanSeeTarget => _canSeeTarget;

        [SerializeField, Range(0, 300)] private float _targetingRange = 10f;
        [SerializeField, Range(0, 360)] private float _targetingAngle = 180;
        [Space]
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private LayerMask _obstacleLayer;

        private Transform _previousTarget;
        private Transform _target;
        private Collider _obstacle;
        private Collider _previousObstacle;

        private float _distanceToTarget;
        private bool _canSeeTarget;

        private void Update()
        {
            SearchForTarget();
        }

        private void SearchForTarget()
        {
            if (TryToGetClosetTargetInAngle(out Transform closestTargetInAngle))
            {
                if (closestTargetInAngle != null)
                {
                    Vector3 direction = (closestTargetInAngle.position - transform.position).normalized;
                    float distance = Vector3.Distance(transform.position, closestTargetInAngle.position);
                    bool isAfterWall = Physics.Raycast(transform.position, direction, distance, _obstacleLayer);

                    if (distance <= _targetingRange && isAfterWall == false)
                    {
                        Debug.DrawLine(transform.position, closestTargetInAngle.position);
                        _target = closestTargetInAngle;
                        return;
                    }
                }
            }

            _target = null;
        }

        private bool TryToGetTargetsAround(out List<Transform> targetsAround)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _targetingRange, _targetLayer, QueryTriggerInteraction.Ignore);
            targetsAround = new List<Transform>();

            if (colliders.Length != 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].attachedRigidbody != null && colliders[i] != GetComponent<Collider>())
                    {
                        targetsAround.Add(colliders[i].attachedRigidbody.transform);
                    }
                }

                return true;
            }

            targetsAround = null;
            return false;
        }

        private bool TryToGetTargetsInAngle(out List<Transform> targetsInAngle)
        {
            if (TryToGetTargetsAround(out List<Transform> targetsAround))
            {
                if (targetsAround.Count != 0)
                {
                    targetsInAngle = new List<Transform>();

                    foreach (Transform targetAround in targetsAround)
                    {

                        Vector3 directionToTarget = (targetAround.position - transform.position).normalized;
                        Debug.Log(Vector3.Angle(transform.position, directionToTarget));

                        if (Vector3.Angle(transform.position, directionToTarget) < _targetingAngle / 2)
                        {
                            targetsInAngle.Add(targetAround);
                        }
                    }

                    return true;
                }
            }

            targetsInAngle = null;
            return false;
        }

        private bool TryToGetClosetTargetInAngle(out Transform closestTargetInAngle)
        {
            if (TryToGetTargetsInAngle(out List<Transform> targetsInAngle))
            {
                if (targetsInAngle.Count != 0)
                {
                    Transform closestTarget = targetsInAngle[0];

                    float previousLowestDistance = Vector3.Distance(transform.position, closestTarget.position);

                    foreach (Transform targetInAngle in targetsInAngle)
                    {
                        float distance = Vector3.Distance(transform.position, targetInAngle.position);

                        if (distance < previousLowestDistance)
                        {
                            closestTarget = targetInAngle;
                            previousLowestDistance = distance;
                        }
                    }

                    closestTargetInAngle = closestTarget;
                    return true;
                }
            }

            closestTargetInAngle = null;
            return false;
        }

        public bool HasTargetAtSight(out Transform target)
        {
            if (_target != null)
            {
                target = _target;
                return true;
            }

            target = null;
            return false;
        }
    }
}
