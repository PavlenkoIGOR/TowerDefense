using TD;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuyControl : MonoBehaviour
{
    [System.Serializable]
    public class TowerAsset
    {        
        public int gold = 15;
        public Sprite towerGUI;
    }
    [SerializeField]private TowerAsset _towerAsset;
    [SerializeField]private TMP_Text _towerText;
    [SerializeField] private Button _button;
    private void GoldStatusCheck(int gold)
    {
        if (gold >= _towerAsset.gold != _button.interactable)
        {
            _button.interactable = !_button.interactable;
            _towerText.color = _button.interactable ? Color.white : Color.red;
        }
    }
    private void Awake()
    {
        Player_TD.OnGoldUpdate += GoldStatusCheck;
    }
    void Start()
    {
        _towerText.text = _towerAsset.gold.ToString();
        _button.GetComponent<Image>().sprite = _towerAsset.towerGUI;
    }

    void Update()
    {
        
    }
}
