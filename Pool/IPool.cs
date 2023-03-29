using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ninja.pool
{
    public interface IPool
    {
        public GameObject TakeFromPool();
        public void PutOnPool(GameObject go);
        
    }

}
