using TD;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class TowerBuyControl : MonoBehaviour
{
    [SerializeField] private TowerAsset _towerAsset;
    public void SetTowerAsset(TowerAsset ta) { _towerAsset = ta; }
    [SerializeField] private TMP_Text _towerText;
    [SerializeField] private Button _button;
    [SerializeField] private Transform _buildSite;
    

    public void SetBuildSite(Transform value)
    {
        _buildSite = value;
    }


    private void GoldStatusCheck(int gold)
    {
        if (gold >= _towerAsset.gold != _button.interactable)
        {
            _button.interactable = !_button.interactable;
            _towerText.color = _button.interactable ? Color.white : Color.red;
        }
    }

    public void Buy()
    {
        Player_TD.Instance.TryBuild(_towerAsset, _buildSite, _towerAsset.tower);
        BuildSite.HideControls();
    }
    private void Awake()
    {

    }
    void Start()
    {
        _towerText.text = _towerAsset.gold.ToString();
        _button.GetComponent<Image>().sprite = _towerAsset.towerGUI;
        Player_TD.Instance.GoldUpdateSubscribe(GoldStatusCheck);
    }

    void Update()
    {

    }
}
