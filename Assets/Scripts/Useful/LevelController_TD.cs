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
    }

    private void StopLvlActivity()
    {
        print("lvl stop");
    }
}
