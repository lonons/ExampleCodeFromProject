using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ninja.systemhp;
using System;

namespace ninja
{
    public class PlayerDeathController : MonoBehaviour, IDisposable
    {
        [SerializeField]
        private GameObject _deathPanel;
        [SerializeField]
        private TMP_Text _m_TextTimer;
        [SerializeField]
        private Image _filledImage;
        [SerializeField]
        private Player _player;
        [SerializeField]
        private float TimeForDeath = 10;

        private SystemHpPlayer _systemHpPlayer;
        private float _deathTimer = 0;
        private bool _isDead = false;

        void Start()
        {
            _systemHpPlayer = (SystemHpPlayer)_player.GetISystemHp;
            _systemHpPlayer.IsDead += PlayerDeath;
        }

        private void PlayerDeath(bool isDeath)
        {
            if (isDeath)
            {
                _deathTimer = TimeForDeath;
                _isDead = true;
                _deathPanel.SetActive(true);
            }
        }

        void Update()
        {
            if (_isDead)
            {
                if (_deathTimer > 0)
                {
                    _deathTimer -= Time.deltaTime;
                    _filledImage.fillAmount = _deathTimer / TimeForDeath;
                    _m_TextTimer.text = _deathTimer.ToString("F0");
                }
                else
                {
                    PlayerLoseLevel();
                }
            }
        }

        public void ButtonReviveClicked()
        {
            _systemHpPlayer.Revive();
            _isDead = false;
            _deathPanel.SetActive(false);
        }
         
        private void PlayerLoseLevel()
        {
            SceneManager.LoadScene(0);
        }

        public void Dispose()
        {
            _systemHpPlayer.IsDead -= PlayerDeath;
        }
    }

}
