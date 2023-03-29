using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja
{
    public class WallLock : MonoBehaviour, IDisposable
    {
        public event Action<int, int> CoinCountForuUnlockWallChanged;

        [SerializeField]
        private int _countCoinForUnlockWall = 1;

        private int _currentCountCoin = 0;
        private void Start()
        {
            Progress.Instance.GetPlayerCurrentInfo.CoinPicked += CoinPicked;
            CoinCountForuUnlockWallChanged?.Invoke(_currentCountCoin, _countCoinForUnlockWall);
        }

        private void CoinPicked(int currentCoin, int countCoin)
        {
            _currentCountCoin += countCoin;
            CoinCountForuUnlockWallChanged?.Invoke(_currentCountCoin, _countCoinForUnlockWall);
            if (_currentCountCoin >= _countCoinForUnlockWall)
            {
                Progress.Instance.GetPlayerCurrentInfo.CoinPicked -= CoinPicked;
                Destroy(gameObject);
            }
               
        }

        public void Dispose()
        {
            Progress.Instance.GetPlayerCurrentInfo.CoinPicked -= CoinPicked;
        }
    }

}
