using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.systemhp
{
    public class SystemHpWall : ISystemHp
    {
        public event Action<int, int> HpChanged;
        public event Action<bool> IsDead;
        private int _maxHp;
        private int _currentHp;

        public SystemHpWall(int maxHp, int currentHp)
        {
            _maxHp = maxHp;
            _currentHp = currentHp;
        }

        public SystemHpWall(int maxHp)
        {
            _maxHp = maxHp;
            _currentHp = maxHp;
        }

        public void GetDamage(int damage)
        {
            if ((_currentHp - damage) <= 0)
            {
                _currentHp = 0;
                HpChanged?.Invoke(_maxHp, _currentHp);
                Dead();
            }
            else
            {
                _currentHp -= damage;
                HpChanged?.Invoke(_maxHp, _currentHp);
            }
        }

        private void Dead()
        {
            IsDead?.Invoke(true);
        }
    }

}
