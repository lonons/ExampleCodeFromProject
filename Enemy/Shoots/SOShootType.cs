using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    [CreateAssetMenu(fileName = "ShootData", menuName = "ScriptableObjects/ShootType", order = 4)]
    public abstract class SOShootType : ScriptableObject
    {
        [SerializeField] private BulletConfig _bulletConfig;
        public BulletConfig GetBulletConfig => _bulletConfig;
    }

}
