using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public class Axe : IItem
    {
        public void Use()
        {
            Debug.Log("Used Axe");
        }
    }

}
