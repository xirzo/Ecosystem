using Game.Inputs;
using UnityEngine;

namespace Game.Movement
{
    public class PlayerMovement : MonoBehaviour, IMovement
    {
        public bool IsWalking => _velocity.magnitude > 0.01f;
        public bool IsRunning => _isRunning;
        public bool CanMove { get; set; }

        [Header("Movement")]
        [Space]
        [SerializeField, Min(0)] private float _movementSpeed = 5f;
        [SerializeField, Min(0)] private float _sprintingSpeed = 5.75f;
        [Space]
        [Header("Input")]
        [SerializeField, Range(0, 1)] private float _smoothInputSpeed = 0.05f;


        private PlayerInputs _inputs;

        private float _speed;
        private bool _isRunning;

        private Vector3 _input;
        private Vector3 _currentInput;
        private Vector3 _smoothInput;

        private Vector3 _velocity;

        private void Awake()
        {
            TryGetComponent(out _inputs);

            SetSpeed(_movementSpeed);
        }

        private void Start()
        {
            _inputs.Actions.Player.Sprint.started += ctx => StartRunning();
            _inputs.Actions.Player.Sprint.canceled += ctx => StopRunning();
        }

        private void OnDestroy()
        {
            _inputs.Actions.Player.Sprint.started -= ctx => StartRunning();
            _inputs.Actions.Player.Sprint.canceled -= ctx => StopRunning();
        }

        private void Update()
        {
            UpdateInput();
            Move();
        }

        private void UpdateInput()
        {
            _input = _inputs.Actions.Player.Movement.ReadValue<Vector3>();
            _currentInput = Vector3.SmoothDamp(_currentInput, _input, ref _smoothInput, _smoothInputSpeed);
        }

        private void Move()
        {
            if (CanMove == true)
            {
                _velocity = transform.forward * _currentInput.z + transform.right * _currentInput.x + Vector3.up * _currentInput.y;
                transform.position += _velocity * _speed * Time.deltaTime;
            }
        }

        private void StartRunning()
        {
            _isRunning = true;

            SetSpeed(_sprintingSpeed);
        }

        private void StopRunning()
        {
            if (_isRunning)
            {
                _isRunning = false;

                SetSpeed(_movementSpeed);
            }

        }

        private void SetSpeed(float value)
        {
            _speed = value;
        }
    }
}
