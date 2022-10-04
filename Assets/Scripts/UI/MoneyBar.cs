using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private PlayerMoney _player;

    private void OnEnable()
    {
        _player.ChangeValue += OnChange;
    }

    private void OnDisable()
    {
        _player.ChangeValue -= OnChange;
    }

    private void Start()
    {
        _money.text = _player.CurrentValue.ToString();
    }

    private void OnChange()
    {
        _money.text = System.Convert.ToInt32(_player.CurrentValue).ToString();
    }
}
