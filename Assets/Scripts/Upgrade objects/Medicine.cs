using UnityEngine;

public class Medicine : UpgradeObject
{
    [Header("Характеристики аптечки")]
    [SerializeField] private int _currentCount;

    public int Count => _currentCount;
}
