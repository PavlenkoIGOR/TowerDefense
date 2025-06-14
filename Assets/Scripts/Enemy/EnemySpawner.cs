using UnityEngine;
using TD;

namespace SpaceShooter
{

    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy _enemyPrefab;
        //[SerializeField] private Path _path;
        [SerializeField] private EnemyAsset[] _enemyAssets;
        protected override GameObject GenerateSpawnEntity()
        {
            var e = Instantiate<Enemy>(_enemyPrefab);
            e.Use(_enemyAssets[Random.Range(0, _enemyAssets.Length)]);

            e.GetComponent<TD_PatrolController>().SetPath(_path);

            return e.gameObject;
        }
    }
}