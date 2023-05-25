using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachines
{
    public abstract class StateMachine : MonoBehaviour
    {
        public event Action<State> OnStateChanged;
        private State _currentState;

        private Dictionary<Type, State> _states = new Dictionary<Type, State>();

        protected virtual void Update()
        {
            _currentState.Update();
        }

        protected virtual void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }

        protected void AddState(State state)
        {
            _states.Add(state.GetType(), state);
        }


        public void SetState<T>() where T : State
        {
            var type = typeof(T);

            if (_currentState != null)
            {
                if (_currentState.GetType() == type)
                {
                    return;
                }
            }

            if (_states.TryGetValue(type, out var newState))
            {
                _currentState?.Exit();

                _currentState = newState;
                _currentState.Enter();
                OnStateChanged?.Invoke(_currentState);
            }
        }
    }
}