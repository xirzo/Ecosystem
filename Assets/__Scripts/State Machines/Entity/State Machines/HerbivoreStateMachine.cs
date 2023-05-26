using Game.Interaction;
using Game.Movement;
using Game.Stats;
using UnityEngine;

namespace Game.StateMachines.Entities.Herbivore
{
    public class HerbivoreStateMachine : EntityStateMachine
    {
        protected override void Awake()
        {
            base.Awake();

            AddState(new HerbivoreStart(this));
            AddState(new HerbivoreIdle(this, Satiety, Thirst));
            AddState(new HerbivoreFoundFood(this, EntityInteractor, Movement));
            AddState(new HerbivoreFoundWater(this, EntityInteractor, Movement));
            AddState(new HerbivoreSearchingForFood(this, EntityInteractor, Movement, DestinationPicker));
            AddState(new HerbivoreSearchingForWater(this, EntityInteractor, Movement, DestinationPicker));
            AddState(new HerbivoreConsumingFood(this, EntityInteractor, Eater, Movement));
            AddState(new HerbivorePatroling(this, Movement, DestinationPicker));
        }

        private void Start()
        {
            SetState<HerbivoreStart>();
        }
    }
}
