using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _continueBttn;
    [SerializeField] private GameObject _warningPanel;
    private void Start()
    {
        _warningPanel.SetActive(false);
        _continueBttn.interactable = FileHandler.HasFile(MapCompletion.filename);
    }
    public void NewGame()
    {
        if (FileHandler.HasFile(MapCompletion.filename))
        {
            _warningPanel.SetActive(true);
        }
        else
        {
            WarningPanelYes();
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }

    public void WarningPanelYes()
    {
        FileHandler.Reset(MapCompletion.filename);
        FileHandler.Reset(Upgrades.fileName);
        SceneManager.LoadScene(1);
    }

    public void WarningPanelNo()
    {
        _warningPanel.SetActive(false);
    }
}
