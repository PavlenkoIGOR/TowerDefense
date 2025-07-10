using SpaceShooter;
using System;
using System.IO;
using UnityEngine;
using static MapCompletion;


[Serializable]
public class Saver<T>
{
    public T data;
    private static string Path(string fileName)
    {
        return $"{Application.persistentDataPath}/{fileName}";
    }
    public static void TryLoad(string fileName, ref T completionData)
    {
        if (File.Exists(Path(fileName)))
        {
            var data = File.ReadAllText(Path(fileName));
            Saver<T> saver = JsonUtility.FromJson<Saver<T>>(data);
            completionData = saver.data;
        }
        else
        {


        }
    }

    public static void Save(string filename, T data)
    {
        var wrapper = new Saver<T> { data = data };
        var dataString = JsonUtility.ToJson(wrapper);
        File.WriteAllText(Path(filename), dataString);
    }

}
