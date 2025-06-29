using SpaceShooter;
using System;
using UnityEngine;
using UnityEngine.Splines;

namespace TD
{
    public class Player_TD : Player
    {
        [SerializeField] private int _gold = 10;
        [SerializeField] private int _lives = 100;
        //[SerializeField] private Tower _towerPref;

        public static new Player_TD Instance { get { return Player.Instance as Player_TD; } }
        private static event Action<int> OnGoldUpdate;
        public static void GoldUpdateSubscribe(Action<int> act)
        {
            OnGoldUpdate += act;
            act(Instance._gold);
        }
        private static event Action<int> OnLifeUpdate;
        public static void LifeUpdateSubscribe(Action<int> act)
        {
            OnLifeUpdate += act;
            act(Instance._lives);
        }

        public void ChangeGold(int change)
        {
            _gold += change;
            OnGoldUpdate(_gold);
        }

        public void ReduceLife(int change)
        {
            TakeDmg(change);
            OnLifeUpdate(numLives);
        }

        public void TryBuild(TowerAsset towerAsset, Transform buildSite, Tower t)
        {
            ChangeGold(-towerAsset.gold);
            var tower = Instantiate(t, buildSite.position, Quaternion.identity);
            tower.GetComponentInChildren<SpriteRenderer>().sprite = towerAsset.sprite;
            Destroy(buildSite.gameObject);
        }
    }
}
