using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.systemhp
{
    public class HeartHeal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player _player))
            {
                
                gameObject.SetActive(false);
            }
        }
    }

}

