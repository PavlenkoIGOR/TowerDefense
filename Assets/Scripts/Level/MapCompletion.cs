using SpaceShooter;
using System;
using UnityEngine;

public class MapCompletion : MonoSingleton<MapCompletion>
{
    public const string filename = "complition.dat";


    [SerializeField] private EpisodeScore[] _completionData;

    [Serializable]
    public class EpisodeScore
    {
        public Episode episode;
        public int score;
    }

    new void Awake()
    {
        base.Awake();
        Saver<EpisodeScore[]>.TryLoad(filename, ref _completionData);
    }
    public bool TryIndex(int id, out Episode ep, out int score)
    {
        if (id >= 0 && id < _completionData.Length)
        {
            ep = _completionData[id].episode;
            score = _completionData[id].score;
            return true;
        }
        ep = null;
        score = 0;
        return false;
    }

    public static void SaveEpisodeResult(int levelScore)
    {
        Instance.SaveResult(LevelSequenceController.Instance.CurrentEpisode, levelScore);
    }



    private void SaveResult(Episode currentEpisode, int levelScore)
    {
        foreach (var item in _completionData)
        {
            if (item.episode == currentEpisode)
            {
                if (levelScore > item.score)
                {
                    item.score = levelScore;
                    Saver<EpisodeScore[]>.Save(filename, _completionData);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
