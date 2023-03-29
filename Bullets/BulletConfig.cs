using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletConfig", order = 2)]
    public class BulletConfig : ScriptableObject
    {
        [SerializeField, Range(1,50)]
        private float _bulletSpeed;

        public float GetBulletSpeed => _bulletSpeed;
    }

}

