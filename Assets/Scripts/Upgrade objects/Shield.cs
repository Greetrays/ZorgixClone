using UnityEngine;

public class Shield : UpgradeObject
{
    [Header("Характеристики щита")]
    [SerializeField] private float _timeAction;

    public float TimeAction => _timeAction;
}
