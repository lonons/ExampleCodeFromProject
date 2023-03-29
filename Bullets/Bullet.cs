using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    public class Bullet : MonoBehaviour
    {
        private float timer = 0;
        private float _bulletSpeed = 10;
        private int _bulletDamage = 10;

        public float BulletSpeed { get => _bulletSpeed; set { _bulletSpeed = value <= 0 ? 10 : value; } }
        public int BulletDamage { get => _bulletDamage; set { _bulletDamage = value <= 0 ? 10 : value; } }
        #region [Unity Metods]
        void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _bulletSpeed);
            //if (gameObject.activeInHierarchy)
            //{
            //    if (timer > 0.4f)
            //    {
            //        gameObject.SetActive(false);
            //        timer = 0;
            //    }
            //    else
            //    {
            //        timer += Time.deltaTime;
            //    }
            //}
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.GetISystemHp.GetDamage(_bulletDamage);
                gameObject.SetActive(false);
            }
            else
            {
                if (collision.gameObject.layer == 6)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        #endregion
    }
}
