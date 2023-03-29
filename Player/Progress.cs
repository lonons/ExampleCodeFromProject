using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ninja
{
    [System.Serializable]
    public class PlayerDataInfo
    {
        public int MaxHp = 100;
        public int CoinCount;
        public int LevelCountUnlocked;
        public int HpHeal = 25;
    }

    public class CurrentPlayerInfo
    {
        public event Action<int,int> CoinPicked;
        private int _maxHp = 100;
        private int _currentHp;
        private int _currentCoin;

        public int CurrentCoin { get {return _currentCoin; } set { _currentCoin += value <= 0 ? 0 : value; CoinPicked?.Invoke(_currentCoin,value); } }
        public int MaxHp { get { return _maxHp; } set { _maxHp = value < 1 ? 1 : value; } }
        public int CurrentHp => _currentHp;

        public void GetHeal(int healCount)
        {
            if (healCount <= 0 ) return;
            else
            {
                _currentHp
            }
        }
        public void GetDamage(int damage)
        {
            if ((_currentHp - damage) <= 0)
            {
                _currentHp = 0;
            }
            else
            {
                _currentHp -= damage;
            }
        }

        public void Revive()
        {
            _currentHp = _maxHp;
        }

        public void RefreshStats(int maxhp) 
        {
            _maxHp = maxhp; 
            _currentHp = _maxHp;
            _currentCoin = 0;
        }
    }

    public class Progress : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void SaveExtern(string data);
        [DllImport("__Internal")]
        private static extern void LoadExtern();
        [DllImport("__Internal")]
        private static extern void ShowAdv();

        public event Action CoinCountChanged;
        public event Action MaxHpChanged;

        public static Progress Instance;

        private PlayerDataInfo _playerDataInfo;
        private CurrentPlayerInfo _playerCurrentInfo;

        public CurrentPlayerInfo GetPlayerCurrentInfo => _playerCurrentInfo;

        public int MaxHp => _playerDataInfo.MaxHp;
        public int GetUnlockedLevels => _playerDataInfo.LevelCountUnlocked;
        public int CoinCount => _playerDataInfo.CoinCount;

        private void Awake()
        {
            if (Instance == null)
            {
                transform.parent = null;
                DontDestroyOnLoad(this.gameObject);
                _playerDataInfo = new PlayerDataInfo();
                _playerCurrentInfo = new CurrentPlayerInfo();
                Instance = this;
#if !UNITY_EDITOR && UNITY_WEBGL
                LoadExtern();
                ShowAdv();
#endif

            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                _playerDataInfo = new PlayerDataInfo();
#if !UNITY_EDITOR && UNITY_WEBGL
                Save();
#endif
            }
        }

        public void AddMaxHp(int _countMaxHpAdd)
        {
            if (_countMaxHpAdd > 0)
            {
                _playerDataInfo.MaxHp += _countMaxHpAdd;
                MaxHpChanged?.Invoke();
            }
        }

        public void CoinAdd(int countCoinForAdd)
        {
            if (countCoinForAdd > 0)
            {
                _playerDataInfo.CoinCount += countCoinForAdd;
                CoinCountChanged?.Invoke();
            }
            else
            {
                Debug.LogWarning("Attempt to add zero or less coins");
            }
        }

        public bool CoinReduse(int countCoinForBuy)
        {
            if (countCoinForBuy < 0)
            {
                Debug.LogWarning("An attempt to reduce the negative number of coins");
                return false;
            }
            if (_playerDataInfo.CoinCount - countCoinForBuy < 0) return false;
            else 
            {
                _playerDataInfo.CoinCount -= countCoinForBuy;
                CoinCountChanged?.Invoke();
                return true;
            }
        }
     
        public void UnlockLevel(int level)
        {
            if (_playerDataInfo.LevelCountUnlocked >= level)
            {
                Debug.Log("the level has already been passed");
            }
            else
            {
                _playerDataInfo.LevelCountUnlocked = level;
            }
        }
       

        public void Save()
        {
            string jsonString = JsonUtility.ToJson(_playerDataInfo);
            SaveExtern(jsonString);
        }

        public void SetPlayerInfo(string value)
        {
            _playerDataInfo = JsonUtility.FromJson<PlayerDataInfo>(value);
        }
    }

}
