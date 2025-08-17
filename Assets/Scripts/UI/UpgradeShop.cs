using System;
using TMPro;
using UnityEngine;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private TMP_Text _moneyTxt;
    [SerializeField] private BuyUpgrade[] _sales;

    private void Start()
    {
        _money = MapCompletion.Instance.totalScore;
        _moneyTxt.text = _money.ToString();

        foreach (var slot in _sales)
        {
            slot.Initialize();
        }
    }

}
