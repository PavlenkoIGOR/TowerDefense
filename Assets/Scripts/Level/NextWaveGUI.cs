using TMPro;
using UnityEngine;

public class NextWaveGUI : MonoBehaviour
{
    [SerializeField] TMP_Text _bonusAmount;
    private EnemyWavesManager _enemyWavesManager;
    private float _timeToNextWave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemyWavesManager = FindAnyObjectByType<EnemyWavesManager>();
        EnemyWave.OnWavePrepare += (float time) =>
        {
            _timeToNextWave = time;
        };
    }

    // Update is called once per frame
    void Update()
    {
        var bonus = (int)_timeToNextWave;
        if (bonus <= 0)
        {
            bonus = 0;
        }
        _bonusAmount.text = bonus.ToString();
        _timeToNextWave -= Time.deltaTime;

    }

    public void CallWave()
    {
        _enemyWavesManager.ForceNextWave();
    }
}
