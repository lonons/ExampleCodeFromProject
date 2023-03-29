using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ninja.game
{
    public class EndStage : MonoBehaviour
    {
        [SerializeField]
        private int _levelNum;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player _player))
            {
                SceneManager.LoadScene(_levelNum);
            }
        }
    }

}
