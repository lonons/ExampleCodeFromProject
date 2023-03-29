using ninja.systemhp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja
{
    public class Spike : MonoBehaviour
    {
        private GameObject _player;
        private ISystemHp _systemhp;
        [SerializeField]
        private int _damage = 1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamagable>(out var damagable))
            {
                _player = other.gameObject;
                _systemhp = damagable.GetISystemHp;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject == _player)
            {
                _systemhp.GetDamage(_damage);
            }
        }
    }
}

