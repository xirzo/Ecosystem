using UnityEngine;
using UnityEngine.AI;

namespace Game.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EntityMovement : MonoBehaviour, IAgentMovement
    {
        public bool IsCloseToDestination => _isCloseToDestination;
        public float DistanceToDestination => Vector3.Distance(transform.position, _agent.destination);
        public float StoppingDistance => _agent.stoppingDistance;
        public float RunStoppingDistance => _runStoppingDistance;
        public bool IsWalking => _agent.velocity.magnitude > 0.01f;
        public bool IsRunning => _isRunning;

        [SerializeField, Min(0)] private float _movementSpeed = 1f;
        [SerializeField, Min(0)] private float _runSpeed = 4f;
        [Space]
        [SerializeField, Min(0)] private float _runStoppingDistance = 8f;

        private NavMeshAgent _agent;

        private float _speed;

        private bool _isRunning;
        private bool _isCloseToDestination;


        private void Awake()
        {
            TryGetComponent(out _agent);

            SetSpeed(_movementSpeed);
        }

        private void Update()
        {
            if (DistanceToDestination > _agent.stoppingDistance)
            {
                _isCloseToDestination = false;

                if (DistanceToDestination > RunStoppingDistance)
                {
                    StartRunning();
                    return;
                }

                StopRunning();
                return;
            }

            _isCloseToDestination = true;
        }

        private void OnDisable()
        {
            ResetDestination();
        }

        public void SetDestination(Vector3 destination)
        {
            _agent.destination = destination;
        }

        public void ResetDestination()
        {
            _agent.ResetPath();
        }

        private void StartRunning()
        {
            if (_isRunning == false)
            {
                SetSpeed(_runSpeed);
                _isRunning = true;
            }
        }

        private void StopRunning()
        {
            if (_isRunning == true)
            {
                SetSpeed(_movementSpeed);
                _isRunning = false;
            }
        }

        private void SetSpeed(float value)
        {
            _speed = value;
            _agent.speed = _speed;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying == true)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(_agent.destination, new Vector3(0.5f, 2, 0.5f));
            }
        }
    }
}
