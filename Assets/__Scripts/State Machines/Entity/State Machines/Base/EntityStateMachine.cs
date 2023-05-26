using Game.Eating;
using Game.Interaction;
using Game.Movement;
using Game.StateMachines.Entities.Herbivore;
using Game.Stats;
using UnityEngine;

namespace Game.StateMachines.Entities
{
    [RequireComponent(typeof(EntityMovement))]
    [RequireComponent(typeof(EntityDestinationPicker))]
    [RequireComponent(typeof(Satiety))]
    [RequireComponent(typeof(Thirst))]
    [RequireComponent(typeof(EntityInteractor))]
    public abstract class EntityStateMachine : StateMachine
    {
        protected EntityMovement Movement => _movement;
        protected EntityDestinationPicker DestinationPicker => _destinationPicker;
        protected Satiety Satiety => _satiety;
        protected Thirst Thirst => _thirst;
        protected Eater Eater => _eater;
        protected EntityInteractor EntityInteractor => _entityInteractor;

        private EntityMovement _movement;
        private EntityDestinationPicker _destinationPicker;
        private Satiety _satiety;
        private Thirst _thirst;
        private Eater _eater;
        private EntityInteractor _entityInteractor;

        protected virtual void Awake()
        {
            TryGetComponent(out _movement);
            TryGetComponent(out _destinationPicker);
            TryGetComponent(out _satiety);
            TryGetComponent(out _thirst);
            TryGetComponent(out _eater);
            TryGetComponent(out _entityInteractor);

            AddState(new EntityDead(this));
        }
    }
}
