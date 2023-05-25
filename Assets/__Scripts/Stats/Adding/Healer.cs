using System;
using UnityEngine;

namespace Game.Stats.Adding
{
    public class Healer : MonoBehaviour, IIncreaser
    {
        public event Action<Health> OnHealed;
        public float Value => _health;

        [SerializeField, Min(0)] private float _health = 10f;

        private void Heal(Health target)
        {
            target.Increase(_health);
            OnHealed?.Invoke(target);
        }


        public void TryToHeal(Health target)
        {
            if (target == null)
                return;

            Heal(target);
        }
    }
}
