using UnityEngine;
using SpaceShooter;
using TD;
public class LevelController_TD : LevelController
{
    private int _levelScore = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private new void Start()
    {
        base.Start();
        Player_TD.Instance.OnPlayerDead += () =>
        {
            StopLvlActivity();
            LevelResultController.Instance.Show(false);
        };

        m_ReferenceTime += Time.deltaTime;

        m_EventLevelCompleted.AddListener(()=>
        {
            StopLvlActivity();
            if (m_ReferenceTime <= Time.deltaTime)
            {
                _levelScore -= 1;
            }
            MapCompletion.SaveEpisodeResult(_levelScore);
        });
        void LifeScoreChange(int _)
        {
            _levelScore -= 1;
            Player_TD.OnLifeUpdate -= LifeScoreChange;
        }
        Player_TD.OnLifeUpdate += LifeScoreChange;
    }

    private void StopLvlActivity()
    {
        foreach (var enemy in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
        {
            enemy.GetComponent<SpaceShip>().enabled = false;
            enemy.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
        }

        DisableAll<Tower>();
        DisableAll<Projectile>();
        DisableAll<Spawner>();
        DisableAll<NextWaveGUI>();
    }

    void DisableAll<T>() where T : MonoBehaviour
    {
        foreach (var obj in FindObjectsByType<T>(FindObjectsSortMode.None))
        {
            obj.enabled = false;
        }
    }
}
