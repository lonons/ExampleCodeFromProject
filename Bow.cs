using UnityEngine;

namespace TestTask
{
    public class Bow : IItem
    {
        public void Use()
        {
            Debug.Log("Used Bow");
        }
    }
}

