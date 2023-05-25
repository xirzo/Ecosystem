using System;
using System.Collections.Generic;
using Game.Movement;
using UnityEngine;

namespace Game.StateMachines
{
    public class EntitySearchForDestination : EntityState
    {
        private EntityDestinationPicker _destinationPicker;

        public EntitySearchForDestination(EntityStateMachine stateMachine, EntityDestinationPicker destinationPicker) : base(stateMachine)
        {
            _destinationPicker = destinationPicker;
        }

        public override void Enter()
        {
            base.Enter();

            _destinationPicker.GetRandomDestinationInDistance();
            Machine.SetState<EntityMoving>();
        }
    }
}
