
using System;
using TD;
using UnityEngine;

public class EnemyWavesManager : MonoBehaviour
{
    [SerializeField] private TD.Path[] _paths;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private EnemyWave _currentWave;
    [SerializeField] private int _activeEnemyCount = 0;
    public event Action OnAllWavesEnd;
    public static event Action<Enemy> OnEnemySpawn;
    void Start()
    {
        _currentWave.Prepare(SpawnEnemies);
    }

    void Update()
    {

    }

    private void RecordEnemyDead()
    {
        if (--_activeEnemyCount == 0)
        {
            ForceNextWave();
        }
    }

    private void SpawnEnemies()
    {
        foreach ((EnemyAsset asset, int count, int pathIndex) squad in _currentWave.EnumerateSquads())
        {
            if (squad.pathIndex < _paths.Length)
            {
                for (int i = 0; i < squad.count; i++)
                {
                    var e = Instantiate<Enemy>(_enemyPrefab, _paths[squad.pathIndex].startArea.RandomInsideZone, Quaternion.identity);
                    e.OnEnd += RecordEnemyDead;
                    e.Use(squad.asset);
                    e.GetComponent<TD_PatrolController>().SetPath(_paths[squad.pathIndex]);
                    _activeEnemyCount++;
                    OnEnemySpawn(e);
                }
            }
            else
            {

            }
        }

        _currentWave = _currentWave.PrepareNext(SpawnEnemies);
    }

    internal void ForceNextWave()
    {
        if (_currentWave)
        {
            Player_TD.Instance.ChangeGold((int)_currentWave.GetRemainingTime());
            SpawnEnemies();
        }
        else
        {
            if (_activeEnemyCount == 0)
            {
                OnAllWavesEnd?.Invoke();
            }

        }
    }
}
