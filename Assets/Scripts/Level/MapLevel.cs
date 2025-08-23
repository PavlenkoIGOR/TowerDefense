using SpaceShooter;
using UnityEngine;
using UnityEngine.UI;

public class MapLevel : MonoBehaviour
{
    [Tooltip("сюда назначается scriptableObj из папки ScriptableObjects/Episodes")]
    public Episode _episode; //
    [SerializeField] private RectTransform _resultPanel;
    [SerializeField] private Image[] _resultImgs;

    public bool isComplete { get { return gameObject.activeSelf && _resultPanel.gameObject.activeSelf; } }

    public void LoadLevel()
    {
        if (_episode)
        {
            LevelSequenceController.Instance.StartEpisode(_episode);
        }
        else
        {

        }
    }

    internal int Initialize()
    {
        var score = MapCompletion.Instance.GetEpisodeScore(_episode);

        _resultPanel.gameObject.SetActive(score > 0);
        for (int i = 0; i < score; i++)
        {
            _resultImgs[i].color = Color.white;
        }
        return score;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
