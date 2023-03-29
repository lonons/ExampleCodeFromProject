using ninja.systemhp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja.enemy
{
    public class ScopePlayer : IDisposable
    {
        private PlayerDetecter _playerDetecter;
        private Player _player;
        private Transform _playerTransform;
        private ISystemHp _systemHpPlayer;

        public Transform GetPlayerTransform => _playerTransform;
        public Player GetPlayer => _player;

        private bool inRadius = false;
        private bool _playerDeath = false;
       
        public ScopePlayer(PlayerDetecter playerDetecter)
        {
            _playerDetecter = playerDetecter;
            _playerDetecter.PlayerDetected += CheckObstacles;
        }
        private void CheckObstacles(bool detected, Transform playerTransform, Player player)
        {
            if (_playerTransform == null) _playerTransform = playerTransform;
            if (_player == null) _player = player;
            if (_systemHpPlayer == null)
            {
                _systemHpPlayer = player.GetISystemHp;
                _systemHpPlayer.IsDead += PlayerDeath;
            } 
            inRadius = detected;
        }

        private void PlayerDeath(bool isDeath)
        {
            _playerDeath = isDeath;
        }

        public bool CheckPlayerInScope()
        {
            if (inRadius && !_playerDeath) return true;
            else return false;
        }

        public void Dispose()
        {
            _playerDetecter.PlayerDetected -= CheckObstacles;
            if (_systemHpPlayer != null) _systemHpPlayer.IsDead -= PlayerDeath;
        }


    }

}
