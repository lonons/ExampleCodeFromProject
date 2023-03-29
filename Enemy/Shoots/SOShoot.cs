using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ninja.enemy
{
    [CreateAssetMenu(fileName = "ShootData", menuName = "ScriptableObjects/ShootType/Shoot", order = 1)]
    public class SOShoot : SOShootType
    {
        [SerializeField,Range(0,180)] private float _maxRandomSpread;

        public float GetMaxRandomSpread => _maxRandomSpread;
    }
}