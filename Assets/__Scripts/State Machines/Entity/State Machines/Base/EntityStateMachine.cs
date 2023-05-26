using Game.Consuming;
using Game.Interaction;
using Game.Movement;
using Game.StateMachines.Entities.Herbivore;
using Game.Stats;
using UnityEngine;

namespace Game.StateMachines.Entities
{
    [RequireComponent(typeof(EntityMovement))]
    [RequireComponent(typeof(EntityDestinationPicker))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Satiety))]
    [RequireComponent(typeof(Thirst))]
    [RequireComponent(typeof(EntityInteractor))]
    public abstract class EntityStateMachine : StateMachine
    {
        protected EntityMovement Movement => _movement;
        protected EntityDestinationPicker DestinationPicker => _destinationPicker;
        protected Health Health => _health;
        protected Satiety Satiety => _satiety;
        protected Thirst Thirst => _thirst;
        protected Consumer Eater => _eater;
        protected EntityInteractor EntityInteractor => _entityInteractor;

        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;
        private Health _health;
        private Satiety _satiety;
        private Thirst _thirst;
        private Consumer _eater;
        private EntityInteractor _entityInteractor;

        protected virtual void Awake()
        {
            TryGetComponent(out _movement);
            TryGetComponent(out _destinationPicker);
            TryGetComponent(out _health);
            TryGetComponent(out _satiety);
            TryGetComponent(out _thirst);
            TryGetComponent(out _eater);
            TryGetComponent(out _entityInteractor);

            AddState(new EntityDead(this));

            _health.OnDied += OnDied;
        }

        protected virtual void OnDestroy()
        {
            _health.OnDied -= OnDied;
        }

        private void OnDied()
        {
            SetState<EntityDead>();
        }
    }
}
