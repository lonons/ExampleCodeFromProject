using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.pool
{
    
    public class PoolController : MonoBehaviour, IDisposable
    {
        [SerializeField]
        private List<SOPoolObject> poolObjects;

     
        static private Dictionary<PoolType, IPool> _poolDictionary = new Dictionary<PoolType, IPool>();

        private void Start()
        {
            Dispose();
            foreach (var pool in poolObjects)
            {
                if (!_poolDictionary.ContainsKey(pool.GetPoolType))
                {
                    CreateNewPool(pool.GetPoolType, pool.GetPrefab);
                }  
            }
        }
        static public IPool GetPoolType(PoolType poolType)
        {
            
            if (_poolDictionary.TryGetValue(poolType,out IPool pool))
            {
                return pool;
            }
            return null;
        }

        private void CreateNewPool(PoolType poolType,GameObject prefab)
        {
            var pool = new GameObject();
            pool.name = $"pool_{poolType.ToString()}";
            pool.transform.SetParent(gameObject.transform);
            Pool component = pool.AddComponent<Pool>();
            component.PoolInitialize(prefab);
            _poolDictionary.Add(poolType,component);
        }

        public void Dispose()
        {
            _poolDictionary.Clear();
        }
    }
    
}
