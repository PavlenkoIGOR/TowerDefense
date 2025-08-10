using SpaceShooter;
using System;
using UnityEngine;

public class MapCompletion : MonoSingleton<MapCompletion>
{
    public const string filename = "complition.dat";


    [SerializeField] private EpisodeScore[] _completionData;
    private int _totalScores;
    public int totalScore { get { return _totalScores; } }

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
        foreach (var episode in _completionData)
        {
            _totalScores += episode.score;
        }
    }

    public static void SaveEpisodeResult(int levelScore)
    {
        if (Instance)
        {
            Instance.SaveResult(LevelSequenceController.Instance.CurrentEpisode, levelScore);
        }
        else
        {
            print($"{levelScore}");
        }
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


    public int GetEpisodeScore(Episode episode)
    {
        foreach (var data in _completionData)
        {
            if (data.episode == episode)
            {
                return data.score;
            }
        }
        return 0;
    }
}
