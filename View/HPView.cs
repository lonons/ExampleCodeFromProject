using System;
using UnityEngine;
using ninja.systemhp;
using TMPro;

namespace ninja.view
{
    public class HPView : MonoBehaviour, IDisposable
    {
        private ISystemHp _systemHpPlayer;
        private TMP_Text text;
        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        public void AddListeners(ISystemHp systemHpPlayer)
        {
            _systemHpPlayer = systemHpPlayer;
            _systemHpPlayer.HpChanged += UpdateViewHP;
            _systemHpPlayer.GetDamage(0);
        }

        private void UpdateViewHP(int maxHp, int currentHp )
        {
            text.text = $"{maxHp}/{currentHp}";
        }

        public void Dispose()
        {
            _systemHpPlayer.HpChanged -= UpdateViewHP;
        }
    }
}

