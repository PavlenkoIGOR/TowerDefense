using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMnuBttn : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
