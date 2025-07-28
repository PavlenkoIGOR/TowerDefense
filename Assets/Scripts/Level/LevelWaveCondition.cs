using SpaceShooter;
using UnityEngine;

public class LevelWaveCondition : MonoBehaviour, ILevelCondition
{
    private bool _isCompleted;
    public bool IsCompleted { get { return _isCompleted; } }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindFirstObjectByType<EnemyWavesManager>().OnAllWavesEnd += () =>
        {
            _isCompleted = true;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
