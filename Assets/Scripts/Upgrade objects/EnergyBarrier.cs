using UnityEngine;

public class EnergyBarrier : UpgradeObject
{
    [Header("Характеристики барьера")]
    [SerializeField] private float _timeAction;

    public float TimeAction => _timeAction;
}
