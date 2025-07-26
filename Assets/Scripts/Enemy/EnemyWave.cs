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

    public static Action<float> OnWavePrepare;
    internal Action OnWaveReady;

    private void Awake()
    {
        enabled = false;
    }
    internal IEnumerable<(EnemyAsset, int, int)> EnumerateSquads()
    {
        for (int i = 0; i < _pathGroups.Length; i++)
        {
            foreach (var squad in _pathGroups[i].squads)
            {
                yield return (squad.asset, squad.count, i);
            }
        }

    }

    internal EnemyWave Next()
    {
        throw new NotImplementedException();
    }

    internal void Prepare(Action spawnEnemies)
    {
        OnWavePrepare?.Invoke(_prepareTime);
        _prepareTime += Time.time;
        enabled = true;
        OnWaveReady += spawnEnemies;
    }

    [SerializeField] private EnemyWave _nextEnemyWave;
    internal EnemyWave PrepareNext(Action spawnEnemies)
    {
        OnWaveReady -= spawnEnemies;
        if (_nextEnemyWave)
        {
            _nextEnemyWave.Prepare(spawnEnemies);
        }

        return _nextEnemyWave;
    }

    public float GetRemainingTime()
    {
        return _prepareTime -  Time.time;
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
