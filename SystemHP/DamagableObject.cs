using ninja.systemhp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja
{
    public class DamagableObject : MonoBehaviour,IDamagable
{
        [SerializeField]
        private GameObject DestroyebleObject;
        [SerializeField]
        private int maxHpWall = 3;
        public ISystemHp GetISystemHp => _systemHp;
        private ISystemHp _systemHp;

        private void Awake()
        {
            _systemHp = new SystemHpWall(maxHpWall);
            _systemHp.IsDead += Dead;
        }

        private void Dead(bool obj)
        {
            Destroy(DestroyebleObject);
        }
    }
}

