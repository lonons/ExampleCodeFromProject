using ninja.systemhp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ninja
{
    public class UIPlayerHp : MonoBehaviour, IDisposable
    {
        [SerializeField, Tooltip("UI HealthBAr Image to fill")]
        private Image _healthBarFilled;

        [SerializeField, Tooltip("Parent object to rotate UI")]
        private Transform _parentTransform;

        [SerializeField]
        private Text _healthText;

        private float _floatMaxhp;
        private float _floatCurrenthp;

        private float _hpPercent;
        private ISystemHp _systemHp;
        private void Start()
        {
            if (gameObject.TryGetComponent(out IDamagable _iDamageble))
            {
                _systemHp = _iDamageble.GetISystemHp;
                _systemHp.HpChanged += HpView;
                _systemHp.GetDamage(0);
            }
            else
            {
                Debug.LogError("Interface IDamageble not fount");
            }
        }

        private void HpView(int _maxHp, int _currentHp)
        {
            _floatCurrenthp = _currentHp;
            _floatMaxhp = _maxHp;
            _hpPercent = _floatCurrenthp / _floatMaxhp;
            _healthBarFilled.fillAmount = _hpPercent;
            _healthText.text = _currentHp.ToString();
        }
        private void LateUpdate()
        {
            _parentTransform.LookAt(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
            _parentTransform.Rotate(0, 180, 0);
        }

        public void Dispose()
        {
            _systemHp.HpChanged -= HpView;
        }
    }

}
