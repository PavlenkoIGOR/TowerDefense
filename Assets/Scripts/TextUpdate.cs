using UnityEngine;
using TD;
using TMPro;
public class TextUpdate : MonoBehaviour
{
    public enum UpdateSource 
    {
        Gold, Lifes
    }
    public UpdateSource updateSource;

    private TMP_Text _text;
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        switch (updateSource)
        {
            case UpdateSource.Gold:
                Player_TD.GoldUpdateSubscribe(UpdateText);
                break;
            case UpdateSource.Lifes:
                Player_TD.LifeUpdateSubscribe(UpdateText);
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateText(int source)
    {
        _text.text = source.ToString();
    }
}
