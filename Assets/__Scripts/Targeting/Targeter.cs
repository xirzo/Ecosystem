using System;
using UnityEngine;

namespace Game.Targeting
{
    public class Targeter : MonoBehaviour, ITargeter
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

        private float _distanceToTarget;
        private bool _canSeeTarget;

        private void Update()
        {
            SearchForTarget();
        }

        private void SearchForTarget()
        {
            if (TryToGetClosestTarget(out Transform closestTarget))
            {
                Vector3 direction = (closestTarget.transform.position - transform.position).normalized;
                _distanceToTarget = Vector3.Distance(transform.position, closestTarget.transform.position);

                _canSeeTarget = !Physics.Raycast(transform.position, direction, out RaycastHit hit, _distanceToTarget, _obstacleLayer);

                if (hit.collider != null)
                {
                    SetObstacle(hit.collider);
                }

                if (_distanceToTarget <= _targetingRange && _canSeeTarget == true)
                {
                    Debug.DrawLine(transform.position, closestTarget.transform.position);

                    SetTarget(closestTarget);

                    return;
                }
            }

            _distanceToTarget = -1;

            SetTarget(null);
        }

        private bool TryToGetClosestTarget(out Transform target)
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, _targetingRange, _targetLayer, QueryTriggerInteraction.Ignore);

            if (targets.Length != 0)
            {
                Collider closestTarget = targets[0];
                float previousLowestDistance = Vector3.Distance(transform.position, closestTarget.attachedRigidbody.transform.position);

                for (int i = 1; i < targets.Length; i++)
                {
                    if (Vector3.Distance(transform.position, targets[i].attachedRigidbody.transform.position) < previousLowestDistance
                    && targets[i] != GetComponent<Collider>())
                    {
                        closestTarget = targets[i];
                        previousLowestDistance = Vector3.Distance(transform.position, closestTarget.attachedRigidbody.transform.position);
                    }
                }

                target = closestTarget.attachedRigidbody.transform;
                return true;
            }

            target = null;
            return false;
        }

        private void SetTarget(Transform target)
        {
            if (target == _target)
            {
                return;
            }


            _previousTarget = _target;
            _target = target;
        }

        private void SetObstacle(Collider obstacle)
        {
            _obstacle = obstacle;
        }
    }
}
