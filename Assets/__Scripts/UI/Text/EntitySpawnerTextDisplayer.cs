using Game.Entities;
using Game.Spawning;
using UnityEngine;

namespace Game.UI
{
    public class EntitySpawnerTextDisplayer : TextDisplayer
    {
        [SerializeField] private EntitySpawner _spawner;

        protected override void Awake()
        {
            base.Awake();

            UpdateStateText();
        }

        private void UpdateStateText()
        {
            SetText(_spawner.Prefab.name);
        }   
    }
}
