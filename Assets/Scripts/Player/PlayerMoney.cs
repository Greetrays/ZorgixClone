using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : PlayerStats
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Medianit medianit))
        {
            TakeRefill(medianit.Count);
        }
    }
}
