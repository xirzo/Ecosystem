using Game.Attacking;
using Game.Targeting;
using UnityEngine;

namespace Game.StateMachines.Entities.Predator
{
    [RequireComponent(typeof(Targeter))]
    [RequireComponent(typeof(IAttacker))]
    public class PredatorStateMachine : EntityStateMachine
    {
        private Targeter _targeter;
        private IAttacker _attacker;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _targeter);
            TryGetComponent(out _attacker); 

            AddState(new PredatorStart(this));
            AddState(new PredatorIdle(this, Satiety, Thirst));
            AddState(new PredatorFoundTarget(this, Movement, _targeter));
            AddState(new PredatorFoundFood(this, EntityInteractor, Movement));
            AddState(new PredatorFoundWater(this, EntityInteractor, Movement));
            AddState(new PredatorSearchingForFood(this, EntityInteractor, Movement, DestinationPicker, _targeter));
            AddState(new PredatorSearchingForWater(this, EntityInteractor, Movement, DestinationPicker));
            AddState(new PredatorAttacking(this, EntityInteractor, Movement, _targeter, _attacker));
            AddState(new PredatorConsuming(this, EntityInteractor, Eater, Movement));
            AddState(new PredatorPatroling(this, Movement, DestinationPicker));
        }

        private void Start()
        {
            SetState<PredatorStart>();
        }
    }
}
