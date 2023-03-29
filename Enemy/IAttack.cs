using ninja.pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    public interface IAttack
    {
        public bool Attack(IPool pool,Vector3 shootVector,Transform shootPoint,int damage);
    }   
} 
