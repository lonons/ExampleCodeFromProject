using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    public class PlayerDetecter : MonoBehaviour
    {
        public Action<bool,Transform,Player> PlayerDetected;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var temp))
            {
                PlayerDetected?.Invoke(true,temp.gameObject.transform,temp);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var temp))
            {
                PlayerDetected?.Invoke(false, temp.gameObject.transform, temp);
            }
        }
    }

}
