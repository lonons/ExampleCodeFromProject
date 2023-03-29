using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ninja.pool;
using System;

namespace ninja.enemy
{
    public class Enemy : MonoBehaviour, ILookOnObject
    {
        public event Action EnemyShoot;
        [SerializeField]
        private EnemyConfig _enemyConfig;
        [SerializeField]
        private Transform _shootPoint;
        [SerializeField]
        private PlayerDetecter _playerDetecter;

        private ScopePlayer _scopePlayer;

        private IAttack _attack;

        private bool _reload = false;

        private float temp = 0;


        #region[UnityMethods]

        private void Start()
        {
            _scopePlayer = new ScopePlayer(_playerDetecter);
            if (_enemyConfig.GetSOSHootType is SOShoot)
            {
                var temp = (SOShoot)_enemyConfig.GetSOSHootType;
                _attack = new Shoot(_enemyConfig.GetSOSHootType.GetBulletConfig,temp.GetMaxRandomSpread);
            }
            if (_enemyConfig.GetSOSHootType is SOShootMultiple)
            {
                var temp = (SOShootMultiple)_enemyConfig.GetSOSHootType;
                _attack = new ShootMultiple(temp.GetBulletConfig, temp.GetBulletCount, temp.GetMaxSpreadAngle);
            }      
            if (_enemyConfig.GetSOSHootType is SOShootPremptive)
            {
                var temp = (SOShootPremptive)_enemyConfig.GetSOSHootType;
                _attack = new ShootPremptive(temp.GetBulletConfig, _playerDetecter);
            }
        }

        private void Update()
        {
            Reload();
            if (_scopePlayer.CheckPlayerInScope())
            {
                if (LookOnObject(_scopePlayer.GetPlayerTransform) && !_reload)
                {
                    Vector3 _directionToPlayer = (_scopePlayer.GetPlayerTransform.position - transform.position);
                    _directionToPlayer = new Vector3(_directionToPlayer.x,0, _directionToPlayer.z);
                    if (_attack.Attack(PoolController.GetPoolType(_enemyConfig.GetBulletType), _directionToPlayer, _shootPoint, _enemyConfig.GetDamage))
                    {
                        EnemyShoot?.Invoke();
                        _reload = true;
                    }
                }
            }
        }
        #endregion

        #region[MyMethods]
        private void Reload()
        {
            if (_reload)
            {
                if (temp < _enemyConfig.GetAttackSpeed)
                {
                    temp += Time.deltaTime;
                }
                else
                {
                    _reload = false;
                    temp = 0;
                }
            }
        }
        public bool LookOnObject(Transform target)
        {
            Vector3 lookTarget = target.position - transform.position;
            Quaternion _finalRotation = Quaternion.LookRotation(new Vector3(lookTarget.x,0, lookTarget.z));
            transform.rotation = Quaternion.Lerp(transform.rotation,_finalRotation,Time.deltaTime * _enemyConfig.GetRotationSpeed);
            if (Quaternion.Angle(_finalRotation, transform.rotation) < _enemyConfig.GetAngleLookForShoot)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}

