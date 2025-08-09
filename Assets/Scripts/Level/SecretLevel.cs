using UnityEngine;

[RequireComponent (typeof(MapLevel))]
public class SecretLevel : MonoBehaviour
{
    internal bool RootIsActive { get { return _rootLvl.isComplete; } }
    [SerializeField] private MapLevel _rootLvl;
    private int _needPoints = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
