using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ninja.game
{
    public class EndLevel : MonoBehaviour
    {
        [SerializeField]
        private int LevelUnlockNum;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player _player))
            {
                Progress.Instance.UnlockLevel(LevelUnlockNum);
                Progress.Instance.CoinAdd(Progress.Instance.GetPlayerCurrentInfo.CurrentCoin);
#if !UNITY_EDITOR && UNITY_WEBGL
                Progress.Instance.Save();
#endif
                SceneManager.LoadScene(0);
            }
        }
    }

}


