using ninja.pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    public class ShootMultiple : IAttack
    {
        private float _bulletCount = 2;

        private float _maxSpreadAngle = 90;

        private BulletConfig _bulletConfig;

        public ShootMultiple(BulletConfig bulletConfig, float bulletCount,float maxSpreadAngle)
        {
            _bulletConfig = bulletConfig;
            _bulletCount = bulletCount;
            _maxSpreadAngle = maxSpreadAngle;
        }

        public bool Attack(IPool pool, Vector3 shootVector, Transform shootPoint,int damage)
        {
            float _avarageForLerp = 1 / (_bulletCount - 1);
            for (int i = 0; i < _bulletCount; i++)
            {
                var _bullet = pool.TakeFromPool();
                if (_bullet.TryGetComponent<Bullet>(out var bullet))
                {
                    bullet.BulletSpeed = _bulletConfig.GetBulletSpeed;
                    bullet.BulletDamage = damage;
                }
                _bullet.transform.position = shootPoint.position;
                _bullet.transform.rotation = Quaternion.LookRotation(shootVector) * 
                    Quaternion.AngleAxis(Mathf.Lerp(-_maxSpreadAngle / 2f, _maxSpreadAngle / 2f, _avarageForLerp * i), Vector3.up);
            }
            return true;
        }
    }

}
