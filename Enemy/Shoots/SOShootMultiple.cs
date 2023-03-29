using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    [CreateAssetMenu(fileName = "ShootMultipleData", menuName = "ScriptableObjects/ShootType/ShootMultiple", order = 2)]
    public class SOShootMultiple : SOShootType
    {
        [SerializeField,Range(2,100)]
        private float _bulletCount = 2;
        [SerializeField, Range(2,360)]
        private float _maxSpreadAngle = 90;

        public float GetBulletCount => _bulletCount;
        public float GetMaxSpreadAngle => _maxSpreadAngle;
    }

}
