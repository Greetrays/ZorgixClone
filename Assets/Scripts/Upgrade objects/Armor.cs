using UnityEngine;

public class Armor : UpgradeObject
{
    [Header("Характеристики брони")]
    [SerializeField] private int _currentCount;

    public int Count => _currentCount;
}
