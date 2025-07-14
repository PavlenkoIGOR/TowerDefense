using System;
using System.IO;
using UnityEngine;


[Serializable]
public class Saver<T>
{
    public T data;

    public static void TryLoad(string fileName, ref T completionData)
    {
        if (File.Exists(FileHandler.Path(fileName)))
        {
            var data = File.ReadAllText(FileHandler.Path(fileName));
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
        File.WriteAllText(FileHandler.Path(filename), dataString);
    }




}
public static class FileHandler
{
    public static string Path(string fileName)
    {
        return $"{Application.persistentDataPath}/{fileName}";
    }
    public static void Reset(string filename)
    {

        var path = FileHandler.Path(filename);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    internal static bool HasFile(string fileName)
    {
        return File.Exists(Path(fileName)); 
    }
}