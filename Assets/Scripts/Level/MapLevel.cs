using UnityEngine;
using SpaceShooter;
using TD;
using System.Data;
using System;
using TMPro;

public class MapLevel : MonoBehaviour
{
    [Tooltip("���� ����������� scriptableObj �� ����� ScriptableObjects/Episodes")]
    private Episode _episode; //

    [SerializeField] private TMP_Text _Text;
    public void LoadLevel()
    {
        if (_episode)
        {
            LevelSequenceController.Instance.StartEpisode(_episode);
        }
        else
        {
            throw new Exception();
        }
    }
    public void SetLeveldata(Episode ep, int score)
    {
        _episode = ep;
        _Text.text = $"{score}/3";
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
