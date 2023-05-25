using System;
using System.Collections.Generic;
using Game.Coloring;
using Game.Entities;
using Game.Gendering;
using Game.ObjectPooling;
using UnityEngine;
using UnityEngine.Analytics;
using Gender = Game.Gendering.Gender;

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
        private Gender _previousEntityGender;

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

            SetEntityGender(spawned);

            if (spawned.TryGetComponent(out EntityColor color))
            {
                color.SetColor(_color.Color);
            }

            _stack.Push(spawned);

            OnSpawned?.Invoke();
        }

        private void SetEntityGender(Entity spawned)
        {
            if (_previousEntityGender == null || _previousEntityGender is FemaleGender)
            {
                MaleGender gender = new MaleGender();
                spawned.SetGender(gender);
                _previousEntityGender = gender;
            }

            else
            {
                FemaleGender gender = new FemaleGender();
                spawned.SetGender(gender);
                _previousEntityGender = gender;
            }
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
