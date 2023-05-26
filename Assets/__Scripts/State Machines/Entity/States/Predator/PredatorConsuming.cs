using Game.Consuming;
using Game.Interaction;
using Game.Interaction.Consume;
using Game.Movement;

namespace Game.StateMachines.Entities.Predator
{
    public class PredatorConsuming : EntityState
    {
        public override string Name => "Predator Consuming";

        private EntityInteractor _interactor;
        private Consumer _eater;
        private EntityMovement _movement;
        private IInteractable _interactable;

        public PredatorConsuming(EntityStateMachine stateMachine, EntityInteractor interactor, Consumer eater, EntityMovement movement) : base(stateMachine)
        {
            _interactor = interactor;
            _eater = eater;
            _movement = movement;
        }

        public override void Enter()
        {
            base.Enter();

            if (_interactor.TryGetClosestAvailableInteractable(typeof(Consumable), out IInteractable interactable) == true)
            {
                _interactable = interactable;
                _interactor.Interact(_interactable);
                return;
            }
        }

        public override void Update()
        {
            base.Update();

            if (_eater.IsEating == false)
            {
                Machine.SetState<PredatorIdle>();
            }
        }
    }
}
