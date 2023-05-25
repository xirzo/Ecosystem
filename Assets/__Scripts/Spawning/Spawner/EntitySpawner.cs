using System;
using System.Collections.Generic;
using Game.Coloring;
using Game.Entities;
using Game.ObjectPooling;
using UnityEngine;

namespace Game.Spawning
{
    [RequireComponent(typeof(SpawnerColor))]
    public class EntitySpawner : MonoBehaviour, ISpawner
    {
        public event Action OnSpawned;
        public event Action OnDespawned;

        public Entity Prefab => _prefab;

        [SerializeField] private Entity _prefab;
        [Space]
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _spawnPoint;
        [Space]
        [SerializeField, Min(0)] private int _initialNumber = 1;

        private SpawnerColor _color;

        private Stack<Entity> _stack;
        private UnlimitedObjectPool<Entity> _pool;

        private void Awake()
        {
            TryGetComponent(out _color);
        }

        private void Start()
        {
            Initialize();
        }

        public void Spawn()
        {
            Entity spawned = _pool.Unpool();

            if (spawned.TryGetComponent(out EntityColor color))
            {
                color.SetColor(_color.Color);
            }

            _stack.Push(spawned);

            OnSpawned?.Invoke();
        }

        public void Despawn()
        {
            Entity despawned = _stack.Pop();
            _pool.Pool(despawned);

            OnDespawned?.Invoke();
        }

        private void Initialize()
        {
            _stack = new Stack<Entity>(_initialNumber);
            _pool = new UnlimitedObjectPool<Entity>(_prefab, _initialNumber, _container, _spawnPoint, false);

            for (int i = 0; i < _initialNumber; i++)
            {
                Spawn();
            }
        }
    }
}
