using System;
using System.Collections.Generic;
using TD;
using TMPro;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [Serializable]
    private class Squad
    {
        public EnemyAsset asset;
        public int count;
    }
    [Serializable]
    private class PathGroup
    { 
        public Squad[] squads;
    }
    [SerializeField] private PathGroup[] _pathGroups;

    [SerializeField] private float _prepareTime = 10.0f;
    internal Action OnWaveReady;

    private void Awake()
    {
        enabled = false;
    }
    internal IEnumerable<(EnemyAsset, int, int)> EnumerateSquads()
    {
        yield return (_pathGroups[0].squads[0].asset, _pathGroups[0].squads[0].count, 0);
    }

    internal EnemyWave Next()
    {
        throw new NotImplementedException();
    }

    internal void Prepare(Action spawnEnemies)
    {
        _prepareTime += Time.time;
        enabled = true;
        OnWaveReady += spawnEnemies;
    }

    internal EnemyWave PrepareNext(Action spawnEnemies)
    {
        return null;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _prepareTime)
        {
            enabled = false;
            OnWaveReady?.Invoke();
        }
    }
}
