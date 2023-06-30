using System;
using System.Collections;
using Game.Stats;
using UnityEngine;

namespace Game.Attacking
{
    public class AttackerBehaviour : MonoBehaviour, IAttacker, IDecreaser
    {
        public event Action OnAttack;
        public event Action OnAttacked;
        public event Action<Stat> OnDecreased;
        public bool IsAttacking => _isAttacking;
        public float DecreaseValue => _healthDecreaseValue;

        [SerializeField, Min(0)] private float _attackingLength = 1f;
        [SerializeField, Min(0)] private float _healthDecreaseValue = 25f;

        private bool _isAttacking;

        public void Attack(Health target)
        {
            StartCoroutine(AttackingCoroutine(target));
        }

        public void Decrease(Stat target)
        {
            target.Decrease(_healthDecreaseValue);
            OnDecreased?.Invoke(target);
        }

        private IEnumerator AttackingCoroutine(Health target)
        {
            OnAttack?.Invoke();
            _isAttacking = true;

            yield return new WaitForSeconds(_attackingLength);

            Decrease(target);
            _isAttacking = false;
            OnAttacked?.Invoke();
        }
    }
}
