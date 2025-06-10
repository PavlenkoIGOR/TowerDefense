using UnityEngine;

namespace SpaceShooter
{

    public class EntitySpawner : Spawner
    {
        [SerializeField] private GameObject[] _entityPrefabs;
        protected override GameObject GenerateSpawnEntity()
        {
            var pref = _entityPrefabs[Random.Range(0, _entityPrefabs.Length)];
            return Instantiate(pref);
        }
    }
}