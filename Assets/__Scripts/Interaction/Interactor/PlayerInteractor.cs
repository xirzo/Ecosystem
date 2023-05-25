using Game.Inputs;
using UnityEngine;

namespace Game.Interaction
{
    [RequireComponent(typeof(PlayerInputs))]
    public class PlayerInteractor : RaycastInteractor
    {
        private PlayerInputs _inputs;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _inputs);
        }

        private void Start()
        {
            _inputs.Actions.Player.Interact.performed += ctx => TryToInteract();
        }

        private void OnDestroy()
        {
            _inputs.Actions.Player.Interact.performed -= ctx => TryToInteract();
        }
    }
}
