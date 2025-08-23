using UnityEngine;

public class LevelDisplayController : MonoBehaviour
{
    [SerializeField] private MapLevel[] _levels;
    [SerializeField] private SecretLevel[] _secretLevels;
    void Start()
    {
        var drawLevel = 0;
        var score = 1;
        while (score != 0 && drawLevel < _levels.Length) 
        {
            score = _levels[drawLevel].Initialize();
            drawLevel += 1;
        }
        for (int i = drawLevel; i < +_levels.Length; i++)
        {
            _levels[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _secretLevels.Length; i++)
        {

            _secretLevels[i].TryActivate();
        }

    }
}
