using UnityEngine;
using SpaceShooter;
using TD;
using System.Data;
using System;

public class MapLevel : MonoBehaviour
{
    [Tooltip("сюда назначается scriptableObj из папки ScriptableObjects/Episodes")]
    [SerializeField] private Episode _episode; //
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

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
