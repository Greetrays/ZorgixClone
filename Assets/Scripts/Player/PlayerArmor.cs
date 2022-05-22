using UnityEngine;

public class PlayerArmor : PlayerStats
{
    private void Start()
    {
        CurrentValue = MaxStats;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Armor armore))
        {
            TakeRefill(armore.Count);
        }
    }
}
