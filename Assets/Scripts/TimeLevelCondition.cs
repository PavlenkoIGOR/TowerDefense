using UnityEngine;
using SpaceShooter;

public class TimeLevelCondition : MonoBehaviour, ILevelCondition
{
    [SerializeField] private float _timeLimit = 4.0f;
    public bool IsCompleted => Time.time > _timeLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
