using Game.Movement;
using UnityEngine;

namespace Game.StateMachines
{
    [RequireComponent(typeof(EntityMovement))]
    [RequireComponent(typeof(EntityDestinationPicker))]
    public class EntityStateMachine : StateMachine
    {
        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;

        private void Awake()
        {
            TryGetComponent(out _movement);
            TryGetComponent(out _destinationPicker);

            AddState(new EntityStart(this));
            AddState(new EntityIdle(this));
            AddState(new EntitySearchForDestination(this, _destinationPicker));
            AddState(new EntityMoving(this, _movement, _destinationPicker));
        }

        private void Start()
        {
            SetState<EntityStart>();
        }
    }
}