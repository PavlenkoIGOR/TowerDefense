using SpaceShooter;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace TD
{
    [RequireComponent(typeof(Destructible))]
    [RequireComponent(typeof(TD_PatrolController))]
    public class Enemy : MonoBehaviour
    {
        internal event Action OnEnd;
        [SerializeField] private int _dmg = 1;
        [SerializeField] private int _gold = 1;
        [SerializeField] private int _armor = 1;
        private Destructible _destructible;

        private void Awake()
        {
            _destructible = GetComponent<Destructible>();
        }
        private void OnDestroy()
        {
            OnEnd?.Invoke();
        }

        public void DamagePlayer()
        {
            Player_TD.Instance.ReduceLife(_dmg);
        }

        public void TakeDmg(int dmg)
        {
            _destructible.ApplyDamage(Mathf.Max(1, dmg - _armor));
        }

        public void GiveGoldForPlayer()
        {
            Player_TD.Instance.ChangeGold(_gold);
        }

        public void Use(EnemyAsset enemyAss)
        {
            var sr = transform.Find("VisualModel").GetComponent<SpriteRenderer>();
            sr.color = enemyAss.color;
            sr.transform.localScale = new Vector3(enemyAss.spriteScale.x, enemyAss.spriteScale.y, transform.localScale.z);

            sr.GetComponent<Animator>().runtimeAnimatorController = enemyAss.controller;

            GetComponent<SpaceShip>().Use(enemyAss);

            GetComponentInChildren<CircleCollider2D>().radius = enemyAss.radius;

            _dmg = enemyAss.dmg;
            _armor = enemyAss.armor;
            _gold = enemyAss.gold;
        }
    }

    [CustomEditor(typeof(Enemy))]
    public class EnemyInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("myCustomEditor");
        }
    }
}