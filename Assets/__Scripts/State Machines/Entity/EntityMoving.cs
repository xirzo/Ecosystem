using System;
using System.Collections.Generic;
using Game.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace Game.StateMachines
{
    public class EntityMoving : EntityState
    {
        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;

        public EntityMoving(EntityStateMachine stateMachine, EntityMovement movement, EntityDestinationPicker destinationPicker) : base(stateMachine)
        {
            _movement = movement;
            _destinationPicker = destinationPicker;
        }

        public override void Enter()
        {
            base.Enter();

            _movement.SetDestination(_destinationPicker.Point);
        }

        public override void Update()
        {
            base.Update();

            if (_movement.Distance > _movement.StoppingDistance)
            {
                if (_movement.Distance > _movement.RunStoppingDistance)
                {
                    _movement.Run();
                    return;
                }

                _movement.Unrun();
                return;
            }

            Machine.SetState<EntityIdle>();
        }
    }
}
