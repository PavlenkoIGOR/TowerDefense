using UnityEngine;
using SpaceShooter;
using TD;
public class LevelController_TD : LevelController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private new void Start()
    {
        base.Start();
        Player_TD.Instance.OnPlayerDead += () =>
        {
            StopLvlActivity();
            LevelResultController.Instance.Show(false);
        };
        m_EventLevelCompleted.AddListener(StopLvlActivity);
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
    }

    void DisableAll<T>() where T : MonoBehaviour
    {
        foreach (var obj in FindObjectsByType<T>(FindObjectsSortMode.None))
        {
            obj.enabled = false;
        }
    }
}
