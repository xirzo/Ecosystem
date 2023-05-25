using UnityEngine;

namespace Game.Sound
{
    //[RequireComponent(typeof (IMoveable))]
    public class FootstepsSoundPlay : CollectionSoundPlayer
    {
        [SerializeField, Min(0)] private float _movementInterval = 0.75f;
        [SerializeField, Min(0)] private float _crouchInvervalMultiplier = 0.825f;
        [SerializeField, Min(0)] private float _sprintInvervalMultiplier = 0.5f;

        //private IMoveable _movement;

        private float _stepInterval = 0.75f;
        private float _footstepTimer = 0;

        protected override void Awake()
        {
            base.Awake();

            //TryGetComponent(out _movement);
        }

        private void Start()
        {
            //_movement.OnStartedCrouching += () => _stepInterval = _crouchInvervalMultiplier;
            //_movement.OnStartedSprinting += () => _stepInterval = _sprintInvervalMultiplier;
            //_movement.OnStoppedCrouching += () => _stepInterval = _movementInterval;
            //_movement.OnStoppedSprinting += () => _stepInterval = _movementInterval;
        }

        private void OnDestroy()
        {
            //_movement.OnStartedCrouching -= () => _stepInterval = _crouchInvervalMultiplier;
            //_movement.OnStartedSprinting -= () => _stepInterval = _sprintInvervalMultiplier;
            //_movement.OnStoppedCrouching -= () => _stepInterval = _movementInterval;
            //_movement.OnStoppedSprinting -= () => _stepInterval = _movementInterval;
        }

        //private void Update()
        ////{
        ////    if (_movement.IsMoving == false || _movement.IsGrounded == false) return;

        ////    _footstepTimer -= Time.deltaTime;

        ////    if (_footstepTimer <= 0)
        ////    {
        ////        PlayOneShot(GetRandomSound());

        ////        _footstepTimer = _stepInterval;
        ////    }
        //}
    }
}
