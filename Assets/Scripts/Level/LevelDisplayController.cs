using UnityEngine;

public class LevelDisplayController : MonoBehaviour
{
    [SerializeField] private MapLevel[] _levels;
    [SerializeField] private SecretLevel[] _secretLevels;
    void Start()
    {
        var drawLevel = 0;
        var score = 1;
        while (score != 0 && drawLevel < _levels.Length && MapCompletion.Instance.TryIndex(drawLevel, out var ep, out score)) 
        {
            _levels[++drawLevel].SetLeveldata(ep, score);

            if (score == 0)
            {
                break;
            }
        }
        for (int i = drawLevel; i < +_levels.Length; i++)
        {
            _levels[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _secretLevels.Length; i++)
        {
            //_secretLevels[i].gameObject.SetActive(_secretLevels[i].RootIsActive);
            _secretLevels[i].TryActivate();
        }

    }
}
