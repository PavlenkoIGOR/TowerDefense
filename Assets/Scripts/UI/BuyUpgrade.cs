using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [SerializeField] private Image _upgradeIcon;
    [SerializeField] private Button _buyBttn;
    [SerializeField] private TMP_Text _levelText, _costText;
    [SerializeField] private UpgradeAsset _upgradeAsset;
    public void Initialize()
    {
        _upgradeIcon.sprite = _upgradeAsset.upgradeSprite;
        var savedLvl = Upgrades.GetUpgradeLevel(_upgradeAsset);
        _levelText.text = $"Level: {savedLvl+1}";
        _costText.text = _upgradeAsset.costByLvl[savedLvl].ToString();
    }

    public void Buy()
    {
        Upgrades.BuyUpgrade(_upgradeAsset);
    }
}
