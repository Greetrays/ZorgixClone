using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerShield))]
[RequireComponent(typeof(PlayerArmor))]

public class PlayerHealth : PlayerStats
{
    [SerializeField] private ParticleSystem _diedParticle;

    public event UnityAction Died;

    private void Start()
    {
        CurrentValue = MaxStats;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Medicine medicine))
        {
            TakeRefill(medicine.Count);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (CurrentValue <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
        Instantiate(_diedParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
