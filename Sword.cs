using UnityEngine;

namespace TestTask
{
    public class Sword : IItem
    {
        public void Use()
        {
            Debug.Log("Used Sword");
        }
    }

}
