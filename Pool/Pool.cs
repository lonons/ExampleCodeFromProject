using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.pool
{
    public class Pool : MonoBehaviour, IPool, IDisposable
    {
        private List<GameObject> _listObjectsInPool = new List<GameObject>(); 

        private int _startPoolObjects = 5;
        private int _nummerable = 1;

        private GameObject _prefab;

     
      
        #region Interface

        public GameObject TakeFromPool()
        {
            foreach (var poolObject in _listObjectsInPool)
            {
                if (!poolObject.activeInHierarchy)
                {
                    poolObject.SetActive(true);
                    return poolObject;
                }
            }
            var temp = CreatePoolObject();
            temp.SetActive(true);
            return temp;

        }

        public void PutOnPool(GameObject go)
        {
            go.SetActive(false);
        }

        #endregion

        public void PoolInitialize(GameObject prefab)
        {
            _prefab = prefab;
            for (int i = 0; i < _startPoolObjects; i++)
            {
                CreatePoolObject();
            }
        }

        private GameObject CreatePoolObject()
        {
            var _poolObject = GameObject.Instantiate(_prefab,transform);
            _poolObject.name = $"{_prefab.name}[{_nummerable}]";
            _nummerable++;
            _poolObject.SetActive(false);
            _listObjectsInPool.Add(_poolObject);
            return _poolObject;
        }

        public void Dispose()
        {
            //foreach (var b in _listObjectsInPool)
            //{
            //    Destroy(b);
            //}
        }
    }
}
