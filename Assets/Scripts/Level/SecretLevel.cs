using System;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent (typeof(MapLevel))]
public class SecretLevel : MonoBehaviour
{
    internal bool rootIsActive { get { return _rootLvl.isComplete; } }
    [SerializeField] private TMP_Text _pointText;
    [SerializeField] private MapLevel _rootLvl;
    [SerializeField] private int _needPoints = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void TryActivate()
    {
        gameObject.SetActive(_rootLvl.isComplete); 

        if (_needPoints > MapCompletion.Instance.totalScore)
        {
            _pointText.text = _needPoints.ToString();
        }
        else
        {
            _pointText.transform.parent.gameObject.SetActive(false);
            GetComponent<MapLevel>().Initialize();

        }

    }
}
