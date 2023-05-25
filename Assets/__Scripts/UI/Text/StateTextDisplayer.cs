using Game.StateMachines;
using UnityEngine;

namespace Game.UI
{
    public class StateTextDisplayer : TextDisplayer
    {
        [SerializeField] private StateMachine _stateMachine;

        protected override void Awake()
        {
            base.Awake();

            _stateMachine.OnStateChanged += UpdateStateText;
        }

        private void OnDestroy()
        {
            _stateMachine.OnStateChanged -= UpdateStateText;
        }

        private void UpdateStateText(State state)
        {
            SetText(state.Name);
        }
    }
}
