using System;
using UnityEngine;
using TMPro;

namespace ninja.view
{
    public class CurrentCoinsView : MonoBehaviour, IDisposable
    {
        private TMP_Text text;
        private void Awake()
        {
            text = GetComponent<TMP_Text>();
            Progress.Instance.GetPlayerCurrentInfo.CoinPicked += UpdateViewCoin;
            UpdateViewCoin(Progress.Instance.GetPlayerCurrentInfo.CurrentCoin , 0);
        }

        private void UpdateViewCoin(int currentCountCoins, int countCoin)
        {
            text.text = $"{currentCountCoins}";
        }

        public void Dispose()
        {
            Progress.Instance.GetPlayerCurrentInfo.CoinPicked -= UpdateViewCoin;
        }
    }
}

