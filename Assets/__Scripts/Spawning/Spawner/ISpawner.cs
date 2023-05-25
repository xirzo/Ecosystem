using System;

namespace Game.Spawning
{
    public interface ISpawner
    {
        public event Action OnSpawned;
        public event Action OnDespawned;
        public void Spawn();
        public void Despawn();
    }
}
