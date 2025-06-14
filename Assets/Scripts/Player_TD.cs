using SpaceShooter;
using UnityEngine;

namespace TD
{
    public class Player_TD : Player
    {
        [SerializeField] private int _gold = 0;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeGold(int change)
        {
            _gold += change;
        }
    }
}
