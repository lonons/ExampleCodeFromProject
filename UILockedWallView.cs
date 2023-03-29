using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace ninja
{
    public class UILockedWallView : MonoBehaviour,IDisposable
    {
        [SerializeField]
        private TMP_Text _text;
        private WallLock _wallLock;

        private void Awake()
        {
            _wallLock = GetComponent<WallLock>();
            _wallLock.CoinCountForuUnlockWallChanged += CoinChenged;
        }

        private void CoinChenged(int _currentCountCoin, int _countCoinForUnlockWall)
        {
            _text.text = $"{_currentCountCoin}/{_countCoinForUnlockWall}";
        }

        public void Dispose()
        {
            _wallLock.CoinCountForuUnlockWallChanged -= CoinChenged;
        }
    }
}
