using UnityEngine;

public class Medianit : UpgradeObject
{
    [Header("Количество монет:")]
    [SerializeField] private int _count;

    public int Count => _count;
}