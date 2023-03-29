using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ninja.mainmenu
{
    [Serializable]
    public class LevelInfo
    {
        public int NumberInSceneLoader;
        public string NameLevel;
    }

    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _shopPanel;

        [SerializeField,Header("Add level buttons strictly in ascending order!!!")]
        private List<LevelInfo> _levelInfoList;

        public List<LevelInfo> LevelInfoList => _levelInfoList;

        private void Start()
        {
            Progress.Instance.GetPlayerCurrentInfo.RefreshStats(Progress.Instance.MaxHp); 
        }

        public void LoadLevel()
        {
            Progress.Instance.GetPlayerCurrentInfo.RefreshStats(Progress.Instance.MaxHp);
            SceneManager.LoadScene(_levelInfoList[Progress.Instance.GetUnlockedLevels].NumberInSceneLoader);
        }
        public void ExitGame()
        {
            Application.Quit();
        }

        public void ShopePanel(bool openOrClose)
        {
            _shopPanel.SetActive(openOrClose);
        }

        public void ShopeBuyUpgradeMaxHp()
        {
            if (Progress.Instance.CoinReduse(5))
            {
                Progress.Instance.AddMaxHp(25);
            }
        }
    }

}
