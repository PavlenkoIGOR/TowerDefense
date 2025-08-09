using UnityEngine;
using SpaceShooter;
using TD;
using System.Data;
using System;
using TMPro;
using UnityEngine.UI;

public class MapLevel : MonoBehaviour
{
    [Tooltip("���� ����������� scriptableObj �� ����� ScriptableObjects/Episodes")]
    private Episode _episode; //
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
    public void SetLeveldata(Episode ep, int score)
    {
        _episode = ep;
        _resultPanel.gameObject.SetActive(score > 0);
        for (int i = 0; i < score; i++)
        {
            _resultImgs[i].color = Color.white;
        }    
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
