using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private TMP_Text _moneyTxt;
    [SerializeField] private BuyUpgrade[] _sales;

    private void Start()
    {


        foreach (var slot in _sales)
        {
            slot.Initialize();
            slot.transform.Find("Button").GetComponent<Button>().onClick.AddListener(UpdateMoney);
        }  
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        _money = MapCompletion.Instance.totalScore;
        _money -= Upgrades.GetTotalCost();
        _moneyTxt.text = _money.ToString();

        foreach (var slot in _sales)
        {
            slot.CheckCost(_money);
        }
    }
}
