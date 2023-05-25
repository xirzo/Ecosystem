using Game.Spawning;
using UnityEngine;

namespace Game.StateMachines
{
    [RequireComponent(typeof(EntitySpawner))]
    public class SpawnerStateMachine : StateMachine
    {
        private EntitySpawner _spawner;

        private void Awake()
        {
            TryGetComponent(out _spawner);

            AddState(new SpawnerStart(this));
        }

        private void Start()
        {
            SetState<SpawnerStart>();
        }
    }
}
