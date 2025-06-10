using SpaceShooter;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace TD
{
    [RequireComponent(typeof(TD_PatrolController))]
    public class Enemy : MonoBehaviour
    {
        public void Use(EnemyAsset enemyAss)
        {
            var sr = transform.Find("VisualModel").GetComponent<SpriteRenderer>();
            sr.color = enemyAss.color;
            sr.transform.localScale = new Vector3(enemyAss.spriteScale.x, enemyAss.spriteScale.y, transform.localScale.z);

            sr.GetComponent<Animator>().runtimeAnimatorController = enemyAss.controller;

            GetComponent<SpaceShip>().Use(enemyAss);

            GetComponentInChildren<CircleCollider2D>().radius = enemyAss.radius;
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