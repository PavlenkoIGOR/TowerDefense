using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] private Image _upgradeIcon;
    [SerializeField] private Button _buyBttn;
    [SerializeField] private TMP_Text _levelText, _costText;
    [SerializeField] private UpgradeAsset _upgradeAsset;
    private int _costNumber= 0;

    public void Initialize()
    {
        _upgradeIcon.sprite = _upgradeAsset.upgradeSprite;
        var savedLvl = Upgrades.GetUpgradeLevel(_upgradeAsset);

        if (savedLvl >= _upgradeAsset.costByLvl.Length)
        {
            _levelText.text += "Level: Max";
            _buyBttn.interactable = false;
            _buyBttn.transform.Find("").gameObject.SetActive(false);
            _costText.text = "X";
            _costNumber = int.MaxValue;
        }
        else
        {
            _levelText.text = $"Level: {savedLvl + 1}";
            _costNumber = _upgradeAsset.costByLvl[savedLvl];
            _costText.text = _costNumber.ToString();
        }
    }

    public void Buy()
    {
        Upgrades.BuyUpgrade(_upgradeAsset);
        Initialize();
    }

    internal void CheckCost(int money)
    {
        _buyBttn.interactable = money >= _costNumber;
    }
}
