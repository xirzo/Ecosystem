using UnityEngine;

namespace Game.StateMachines
{
    public abstract class State
    {
        protected StateMachine Machine { get; private set; }

        public State(StateMachine stateMachine)
        {
            Machine = stateMachine;
        }

        public virtual void Enter()
        {
            //Debug.Log($"State Entered: {this}");
        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void Exit()
        {

        }
    }
}