using ninja.systemhp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Player))]
    public class PlayerAnimatorController : MonoBehaviour, IDisposable
    {
        private Player _player;
        private Animator _animator;
        private ISystemHp _systemHp;

        public void Dispose()
        {
            _player.Velocity -= Movement;
            _systemHp.IsDead -= Death;
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _player = GetComponent<Player>();
        }

        private void Start()
        {
            _systemHp = _player.GetISystemHp;
            _player.Velocity += Movement;
            _systemHp.IsDead += Death;
        }

        private void Death(bool isDeath)
        {
            if (isDeath)
            _animator.SetTrigger("IsDeath");
            else
            _animator.SetTrigger("IsRevive");
        }

        private void Movement(Vector3 _direction)
        {
            if (_direction == Vector3.zero)
            {
                _animator.SetBool("IsRun",false);
            }
            else
            {
                _animator.SetBool("IsRun", true);
            }
        }



    }

}
