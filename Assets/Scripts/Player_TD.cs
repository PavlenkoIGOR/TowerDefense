using SpaceShooter;
using System;
using UnityEngine;

namespace TD
{
    public class Player_TD : Player
    {
        [SerializeField] private int _gold = 10;
        [SerializeField] private int _lives = 100;

        public static new Player_TD Instance { get { return Player.Instance as Player_TD; } }
        public static event Action<int> OnGoldUpdate;
        public static event Action<int> OnLifeUpdate;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            OnGoldUpdate(_gold);
            OnLifeUpdate(_lives);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeGold(int change)
        {
            _gold += change;
            OnGoldUpdate(_gold);
        }

        public void ReduceLife(int change)
        {
            //_lifes += change;
            TakeDmg(change);
            OnLifeUpdate(numLives);
        }
    }
}
