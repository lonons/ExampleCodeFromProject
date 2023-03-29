using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace ninja.mainmenu
{
    public class ViewMainStatsProgress : MonoBehaviour, IDisposable
    {
        [SerializeField]
        private MainMenuController _mainMenuController;

        [SerializeField]
        private TMP_Text _maxHp;
        [SerializeField]
        private TMP_Text _coins;
        [SerializeField]
        private TMP_Text _currentLevelsOpened;

        
        private void Start()
        {
            _coins.text = $"{Progress.Instance.CoinCount}";
            _maxHp.text = $"{Progress.Instance.MaxHp}";
            _currentLevelsOpened.text = $"{_mainMenuController.LevelInfoList[Progress.Instance.GetUnlockedLevels].NameLevel}";
            Progress.Instance.CoinCountChanged += CoinCountChanged;
            Progress.Instance.MaxHpChanged += MaxHpChanged;
        }

        private void MaxHpChanged()
        {
            _maxHp.text = $"{Progress.Instance.MaxHp}";
        }

        private void CoinCountChanged()
        {
            _coins.text = $"{Progress.Instance.CoinCount}";
        }

        public void Dispose()
        {
            Progress.Instance.CoinCountChanged -= CoinCountChanged;
            Progress.Instance.MaxHpChanged -= MaxHpChanged;
        }
    }

}
