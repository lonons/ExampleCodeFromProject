using ninja.enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]

public class EnemyAnimatorController : MonoBehaviour, IDisposable
{
    private Enemy _enemy;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }
    private void Start()
    {
        _enemy.EnemyShoot += Shooting;
    }

    private void Shooting()
    {
        _animator.SetTrigger("EnemyShoot");
    }

    public void Dispose()
    {
        _enemy.EnemyShoot -= Shooting;
    }

}
