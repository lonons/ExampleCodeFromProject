using ninja.pool;
using UnityEngine;

namespace ninja.enemy
{
    public class Shoot : IAttack
    {

        private BulletConfig _bulletConfig;
        private float _maxRandomSpread;

        public Shoot(BulletConfig bulletConfig, float maxRandomSpread)
        {
            _bulletConfig = bulletConfig;
            _maxRandomSpread = maxRandomSpread;
        }

        public bool Attack(IPool pool, Vector3 shootVector, Transform shootPoint,int damage)
        {
            var _bullet = pool.TakeFromPool();
            if (_bullet.TryGetComponent<Bullet>(out var bullet)) 
            {
                bullet.BulletSpeed = _bulletConfig.GetBulletSpeed;
                bullet.BulletDamage = damage;
            }
            _bullet.transform.position = shootPoint.position;
            _bullet.transform.rotation = Quaternion.LookRotation(shootVector) * Quaternion.AngleAxis(Random.Range(-_maxRandomSpread,_maxRandomSpread), Vector3.up);
            return true;
        }
    }
}

