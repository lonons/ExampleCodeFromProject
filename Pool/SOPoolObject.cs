using UnityEngine;

namespace ninja.pool 
{
    [CreateAssetMenu(fileName = "PoolObjectData", menuName = "ScriptableObjects/PoolObject", order = 1)]
    public class SOPoolObject : ScriptableObject
    {
        [SerializeField, Tooltip("Pool type should not be duplicated")]
        private PoolType _poolType;
        [SerializeField]
        private GameObject _prefab;

        public PoolType GetPoolType => _poolType;
        public GameObject GetPrefab => _prefab;
    }

}
