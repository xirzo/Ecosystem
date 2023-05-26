using Game.Movement;
using UnityEngine;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorStateMachine : EntityStateMachine
    {
        protected override void Awake()
        {
            base.Awake();

            AddState(new PredatorStart(this));
            AddState(new PredatorIdle(this, Satiety, Thirst));
            AddState(new PredatorFoundFood(this, EntityInteractor, Movement));
            AddState(new PredatorFoundWater(this, EntityInteractor, Movement));
            AddState(new PredatorSearchingForFood(this, EntityInteractor, Movement, DestinationPicker));
            AddState(new PredatorSearchingForWater(this, EntityInteractor, Movement, DestinationPicker));
            AddState(new PredatorConsuming(this, EntityInteractor, Eater, Movement));
            AddState(new PredatorPatroling(this, Movement, DestinationPicker));
        }

        private void Start()
        {
            SetState<PredatorStart>();
        }
    }
}
