using System;
using Game.Stats;

namespace Game.Attacking
{
    public interface IAttacker
    {
        public event Action OnAttack;
        public event Action OnAttacked;
        public bool IsAttacking { get; }
        public void Attack(Health target);
    }
}
