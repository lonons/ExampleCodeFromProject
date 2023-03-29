using ninja.items;
using ninja.systemhp;
using ninja.view;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ninja
{
    public class Player : MonoBehaviour, IDamagable, IPlayer, IDisposable
    {
        public event Action<Vector3> Velocity;

        public ISystemHp GetISystemHp => _systemHp;

        public ItemPicker GetItemPicker => _itemPicker;
        [SerializeField]
        private FloatingJoystick _floatingJoystick;
        [SerializeField]
        private Rigidbody _rb;
        [SerializeField]
        private Transform _playerModel;
        [SerializeField]
        private float _moveSpeed = 4;
        [SerializeField]
        private float _speedRotation = 10f;

        private ISystemHp _systemHp;
        private ItemPicker _itemPicker;
        private Vector3 _direction;

        private bool _playerIsDeath = false;

        public Vector3 GetDirection => _direction;

        public void Dispose()
        {
        }
        #region [UnityMetods]
        private void Awake()
        {
            _systemHp = new SystemHpPlayer(Progress.Instance.GetPlayerCurrentInfo.MaxHp,Progress.Instance.GetPlayerCurrentInfo.CurrentHp);
            
            _itemPicker = new ItemPicker();
        }

        private void Start()
        {
            _systemHp.IsDead += PlayerDeath;
        }

        private void PlayerDeath(bool isDead)
        {
            _playerIsDeath = isDead;
        }

        private void Update()
        {
            if (!_playerIsDeath) Movement();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IPickable>(out var pickable))
            {
                pickable.ItemPicked();
            }
        }
        #endregion

        #region [MyMethods]

        private void Movement()
        {
            _direction = new Vector3(_floatingJoystick.Horizontal, _rb.velocity.y, _floatingJoystick.Vertical).normalized;
            _direction = _direction * _moveSpeed;
            _direction.y = _rb.velocity.y;
            _rb.velocity = _direction;
            if (_floatingJoystick.Horizontal != 0 || _floatingJoystick.Vertical != 0)
            {
                _playerModel.transform.rotation = Quaternion.Lerp(transform.rotation, 
                    Quaternion.LookRotation(new Vector3(_floatingJoystick.Horizontal * _moveSpeed, 0, _floatingJoystick.Vertical * _moveSpeed)), 
                    Time.deltaTime * _speedRotation);
            }
            Velocity?.Invoke(_direction);
        }

        #endregion

    }

}
