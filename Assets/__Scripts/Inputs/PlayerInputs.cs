using UnityEngine;

namespace Game.Inputs
{
    public class PlayerInputs : MonoBehaviour
    {
        public InputActions Actions { get; private set; }

        private void Awake()
        {
            Actions = new InputActions();
        }

        private void OnEnable()
        {
            Actions.Enable();
        }

        private void OnDestroy()
        {
            Actions.Disable();
        }
    }
}
