using ninja.pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    public class ShootPremptive : IAttack, IDisposable
    {
        private BulletConfig _bulletConfig;
        private PlayerDetecter _playerDetecter;
        private Player _player;

        public ShootPremptive(BulletConfig bulletConfig, PlayerDetecter playerDetecter)
        {
            _bulletConfig = bulletConfig;
            _playerDetecter = playerDetecter;
            _playerDetecter.PlayerDetected += PlayerDetected;
        }

        private void PlayerDetected(bool arg1, Transform arg2, Player arg3)
        {
            if (_player == null)
            {
                _player = arg3;
            }
            _playerDetecter.PlayerDetected -= PlayerDetected;
        }

        public bool Attack(IPool pool, Vector3 shootVector, Transform shootPoint, int damage)
        {
            float timeToHit = shootVector.magnitude / _bulletConfig.GetBulletSpeed;
            Vector3 targetForShoot = _player.transform.position + (_player.GetDirection * timeToHit);
            targetForShoot = (targetForShoot - shootPoint.position).normalized;
            targetForShoot.y = 0;
            
            var _bullet = pool.TakeFromPool();
            if (_bullet.TryGetComponent<Bullet>(out var bullet))
            {
                bullet.BulletSpeed = _bulletConfig.GetBulletSpeed;
                bullet.BulletDamage = damage;
            }
            _bullet.transform.position = shootPoint.position;
            _bullet.transform.rotation = Quaternion.LookRotation(targetForShoot);
            return true;
        }

        public void Dispose()
        {
            _playerDetecter.PlayerDetected -= PlayerDetected;
        }
    }

}
