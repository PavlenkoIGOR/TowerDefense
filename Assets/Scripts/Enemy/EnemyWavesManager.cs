
using TD;
using UnityEngine;

public class EnemyWavesManager : MonoBehaviour
{
    [SerializeField] private TD.Path[] _paths;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private EnemyWave _currentWave;


    void Start()
    {
        _currentWave.Prepare(SpawnEnemies);
    }

    void Update()
    {

    }

    private void SpawnEnemies()
    {
        foreach ((EnemyAsset asset, int count, int pathIndex) squad in _currentWave.EnumerateSquads())
        {
            if (squad.pathIndex < _paths.Length)
            {
                for (int i = 0; i < squad.count; i++)
                {
                    var e = Instantiate<Enemy>(_enemyPrefab);
                    e.Use(squad.asset);
                    e.GetComponent<TD_PatrolController>().SetPath(_paths[squad.pathIndex]);

                }
            }
            else
            {

            }
        }

        _currentWave = _currentWave.PrepareNext(SpawnEnemies);
    }
}
