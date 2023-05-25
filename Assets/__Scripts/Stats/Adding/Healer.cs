using System;
using UnityEngine;

namespace Game.Stats
{
    public class Healer : MonoBehaviour, IIncreaser
    {
        public event Action<Health> OnIncrease;
        public float Value => _health;

        [SerializeField, Min(0)] private float _health = 10f;

        private void Heal(Health target)
        {
            target.Increase(_health);
            OnIncrease?.Invoke(target);
        }


        public void Increase(Health target)
        {
            if (target == null)
                return;

            Heal(target);
        }
    }
}
