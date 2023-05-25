using System;
using Game.Inputs;
using Game.Interaction;
using Game.Movement;
using Game.Orientations;
using UnityEngine;

namespace Game.Spectating
{
    [RequireComponent(typeof(PlayerInputs))]
    [RequireComponent(typeof(PlayerInteractor))]
    [RequireComponent(typeof(PlayerCamera))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerSpectator : Spectator
    {
        private PlayerInputs _inputs;
        private PlayerInteractor _interactor;
        private PlayerCamera _playerCamera;
        private PlayerMovement _movement;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _inputs);
            TryGetComponent(out _interactor);
            TryGetComponent(out _playerCamera);
            TryGetComponent(out _movement);
        }

        private void Start()
        {
            OnIsSpectatingChanged += OnSpectatingChanged;
            _inputs.Actions.Player.Unspectate.performed += ctx => Unspectate();
            _interactor.OnInteracted += OnInteracted;
        }

        private void OnDestroy()
        {
            OnIsSpectatingChanged -= OnSpectatingChanged;
            _inputs.Actions.Player.Unspectate.performed -= ctx => Unspectate();
            _interactor.OnInteracted -= OnInteracted;
        }

        private void OnSpectatingChanged(bool condition)
        {
            if (condition == true)
            {
                _playerCamera.CanRotate = false;
                _movement.CanMove = false;

                return;
            }

            _playerCamera.CanRotate = true;
            _movement.CanMove = true;

            _inputs.Actions.Player.Enable();
        }

        private void OnInteracted(IInteractable interactable)
        {
            if (interactable.Self.TryGetComponent(out ISpectatorable spectatorable))
            {
                Spectate(spectatorable);
                return;
            }

            throw new Exception($"IInteractable: {interactable} doesn`t have ISpectatorable");
        }
    }
}
