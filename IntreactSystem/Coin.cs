using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.items
{
    public class Coin : MonoBehaviour, IPickable, IDisposable
    {

        [SerializeField]
        private int _coinCount = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player _player))
            {
                Progress.Instance.GetPlayerCurrentInfo.CurrentCoin = _coinCount;
                gameObject.SetActive(false);
            }
        }
        public void ItemPicked()
        {
            
        }
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }

}
