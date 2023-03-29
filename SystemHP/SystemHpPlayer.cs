using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ninja.systemhp
{
    public class SystemHpPlayer : ISystemHp, IDisposable
    {
        public event Action<int, int> HpChanged;
        public event Action<bool> IsDead;

        private int _maxHp;
        private int _currentHp;
        private bool _isDeath = false;

        public SystemHpPlayer(int maxHp)
        {
            _maxHp = maxHp;
            _currentHp = _maxHp;
            HpChanged?.Invoke(_maxHp, _currentHp);
        }
        public SystemHpPlayer(int maxHp,int currentHp )
        {
            _maxHp = maxHp;
            _currentHp = currentHp;
            HpChanged?.Invoke(_maxHp, _currentHp);
        }

        public void GetDamage(int damage)
        {
            if (!_isDeath)
            {
                if ((_currentHp - damage) <= 0)
                {
                    _currentHp = 0;
                    Progress.Instance.GetPlayerCurrentInfo.GetDamage(damage);
                    HpChanged?.Invoke(_maxHp, _currentHp);
                    Dead();
                }
                else
                {
                    // _frameGodMod.EnableGodMod();
                    _currentHp -= damage;
                    Progress.Instance.GetPlayerCurrentInfo.GetDamage(damage);
                    HpChanged?.Invoke(_maxHp, _currentHp);
                }
            }
        }

        public void Revive()
        {
            _currentHp = _maxHp;
            Progress.Instance.GetPlayerCurrentInfo.Revive();
            IsDead?.Invoke(false);
            _isDeath = false;
            HpChanged?.Invoke(_maxHp, _currentHp);
        }

        private void Dead()
        {
            IsDead?.Invoke(true);
            _isDeath = true;
        }

        public void Dispose()
        {
            
        }
    }

}
