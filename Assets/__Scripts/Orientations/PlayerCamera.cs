using System;
using Game.Inputs;
using Game.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Orientations
{
    [RequireComponent(typeof(PlayerInputs))]
    public class PlayerCamera : Orientation
    {
        public bool CanRotate { get; set; }

        [Space]
        [SerializeField, Min(0)] private float _sensitivityX = 0.05f;
        [SerializeField, Min(0)] private float _sensitivityY = 0.05f;
        [Space]
        [SerializeField, Min(0)] private float _gamepadSevsitivityMultiplier = 20f;
        [Space]
        [SerializeField, Range(0, 90)] private float _upperRotationXClamp = 90f;
        [SerializeField, Range(0, -90)] private float _lowerRotationXClamp = -90f;

        private PlayerInputs _inputs;

        private Vector2 _mouse;

        private float _rotationX;
        private float _rotationY;

        private Camera _camera;

        private void Awake()
        {
            TryGetComponent(out _inputs);
            OrientationObject.TryGetComponent(out _camera);
        }

        protected override void Update()
        {
            base.Update();

            UpdateInput();
            HandleRotation();
        }

        public override Vector3 GetForwardPoint(float maxDistance = 100)
        {
            Ray ray = GetCameraRay();

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
            Ray ray = GetCameraRay();
            return ray.direction;
        }

        private Ray GetCameraRay()
        {
            return _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        }


        private void UpdateInput()
        {
            _mouse = _inputs.Actions.Player.Look.ReadValue<Vector2>();
        }

        private void HandleRotation()
        {
            if (CanRotate == true)
            {
                var gamepad = Gamepad.current;

                if (gamepad == null)
                {
                    _rotationY += _mouse.x * _sensitivityX;
                    _rotationX -= _mouse.y * _sensitivityY;
                }

                else
                {
                    _rotationY += _mouse.x * _sensitivityX * _gamepadSevsitivityMultiplier;
                    _rotationX -= _mouse.y * _sensitivityY * _gamepadSevsitivityMultiplier;
                }

                _rotationX = Mathf.Clamp(_rotationX, _lowerRotationXClamp, _upperRotationXClamp);

                transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
            }
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(OrientationObject.transform.position, OrientationObject.transform.forward * RaycastDistance);
            }
        }
    }
}
