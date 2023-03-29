using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ninja.pool;

namespace ninja.enemy
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyConfig", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField,Range(0.1f,10f),Tooltip("Delay before firing")]
        private float _attackSpeed;
        [SerializeField]
        private int _damage = 10;
        [SerializeField]
        private PoolType _bulletType;
        [SerializeField]
        private SOShootType _shootType;
        [SerializeField, Range(1f,10f),Tooltip("Model rotation speed")]
        private float _rotationSpeed;
        [SerializeField, Range(15f,180f),Tooltip("The error of the angle between the direction vector to the player for the shot")]
        private float _angleLookForShoot;

        public PoolType GetBulletType => _bulletType;
        public float GetAttackSpeed => _attackSpeed;
        public SOShootType GetSOSHootType => _shootType;
        public float GetRotationSpeed => _rotationSpeed;
        public float GetAngleLookForShoot => _angleLookForShoot;
        public int GetDamage => _damage;

    }

}
