using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public class Player : MonoBehaviour
    {
        private Inventory _inventory;
        private void Start()
        {
            _inventory = new Inventory();
            _inventory.AddItem(new Sword());
            _inventory.AddItem(new Axe());
            _inventory.AddItem(new Bow());
            for (int i =0; i < _inventory.ItemsCount; i++)
            {
                _inventory.TakeItem(i).Use();
            }
            while (_inventory.ItemsCount > 0)
            {
                _inventory.RemoveItem(0);
            }
        }
    }

}
