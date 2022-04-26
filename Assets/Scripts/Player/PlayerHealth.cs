﻿using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerShield))]
[RequireComponent(typeof(PlayerArmor))]

public class PlayerHealth : PlayerStats
{
    [SerializeField] private ParticleSystem _diedParticle;

    private PlayerShield _playerShield;
    private PlayerArmor _playerArmor;
    private UnityEvent _died;

    public event UnityAction Dying;

    public bool IsShieldActive { get; private set; }

    private void OnValidate()
    {
        if (MaxStats <= 0)
        {
            MaxStats = 25;
        }
    }

    private void Start()
    {
        CurrentStats = MaxStats;
        _playerShield = GetComponent<PlayerShield>();
        _playerArmor = GetComponent<PlayerArmor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Medicine medicine))
        {
            Refilling();

            if (CurrentStats + medicine.Count > MaxStats)
            {
                int newValueStats = MaxStats - CurrentStats;
                Change(newValueStats);
            }
            else if (CurrentStats + medicine.Count <= MaxStats)
            {
                Change(medicine.Count);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_playerShield.IsShield == false)
        {
            int fullPercantage = 100;
            int newDamage = damage * (fullPercantage - _playerArmor.CurrentStats) / fullPercantage;
            
            Decreasing();

            if (CurrentStats - newDamage > 0)
            {
                Change(-newDamage);
            }
            else
            {
                newDamage = CurrentStats;
                Change(-newDamage);
            }

            if (CurrentStats <= 0)
            {
                Died();
            }
        }
    }

    private void Died()
    {
        Dying?.Invoke();
        Instantiate(_diedParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
