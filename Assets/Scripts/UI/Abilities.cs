using System;
using System.Collections;
using SpaceShooter;
using TD;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoSingleton<Abilities>
{
    [SerializeField] private Button _timeBttn;
    [SerializeField] private Image _targetCircle;
    [SerializeField] private FireAbility _fireAbility;
    [SerializeField] private TimeAbility _timeAbility;


    [Serializable]
    public class FireAbility
    {
        [SerializeField] private float _cost = 5;
        [SerializeField] private int _dmg = 2;
        [SerializeField] private Color _targetingColor;
        public void Use()
        {
            ClickProtection.Instance.Activate((Vector2 v) =>
            {
                Vector3 position = v;
                position.z = -Camera.main.transform.position.z;
                position = Camera.main.ScreenToWorldPoint(position);
                foreach (var collider in Physics2D.OverlapCircleAll(position, 5))
                {
                    print(collider.name);
                    if (collider.transform.parent.TryGetComponent<Enemy>(out var enemy))
                    {
                        enemy.TakeDmg(_dmg, TD_Projectile.DamageType.Magic);
                    }

                }

            });
        }
    }

    //private void InitiateTargeting(Color c, Action<Vector2> mouseAction)
    //{
    //   // _targetCircle.color = c;
    //    ClickProtection.Instance.Activate(mouseAction);
    //}

    public void UseFireAbility() => _fireAbility.Use();

    [Serializable]
    public class TimeAbility
    {
        [SerializeField] private float _duration = 5.0f;
        [SerializeField] private float _cooldown = 15.0f;
        [SerializeField] private int _cost = 10;
        public void Use()
        {
            void Slow(Enemy enemy)
            {
                enemy.GetComponent<SpaceShip>().HalfMaxLinearVelocity();
            }



            foreach (var ship in FindObjectsByType<SpaceShip>(sortMode: FindObjectsSortMode.None))
            {
                ship.HalfMaxLinearVelocity();
            }

            EnemyWavesManager.OnEnemySpawn += Slow;

            IEnumerator Restore()
            {
                yield return new WaitForSeconds(_duration);

                foreach (var ship in FindObjectsByType<SpaceShip>(sortMode: FindObjectsSortMode.None))
                {
                    ship.RestoreMaxLinearVelocity();
                }
                EnemyWavesManager.OnEnemySpawn -= Slow;
            }

            Instance.StartCoroutine(Restore());


            IEnumerator TimeAbilityBttn()
            {
                Instance._timeBttn.interactable = false;
                yield return new WaitForSeconds(_cooldown);
                Instance._timeBttn.interactable = true;
            }

            Instance.StartCoroutine(TimeAbilityBttn());
        }
    }


    public void UseTimeAbility() => _timeAbility.Use();
    //public void UseFireAbility() => _timeAbility.Use();
}
