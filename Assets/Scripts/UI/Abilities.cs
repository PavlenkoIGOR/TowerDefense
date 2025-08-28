using System;
using System.Collections;
using SpaceShooter;
using TD;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoSingleton<Abilities>
{
    [SerializeField] private Button _timeBttn;
    [SerializeField] private FireAbility _fireAbility;
    [SerializeField] private TimeAbility _timeAbility;
    public interface Usable { void Use(); }

    [Serializable]
    public class FireAbility : Usable
    {
        [SerializeField] private float _cost = 5;
        [SerializeField] private int _dmg = 2;
        public void Use()
        {
        }
    }

    public void UseFireAbility() => _fireAbility.Use();

    [Serializable]
    public class TimeAbility : Usable
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
}
