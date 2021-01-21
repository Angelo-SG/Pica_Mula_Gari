using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadSys
{
    public static void SaveScore(ScoreData score)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/score.data";
        FileStream stream;

        if (File.Exists(path))
        {
            stream = new FileStream(path, FileMode.Open);
        }
        else
        {
            stream = new FileStream(path, FileMode.Create);
        }

        ScoreData data = score;

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static ScoreData LoadScore()
    {
        string path = Application.persistentDataPath + "/score.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();
            
            return data;
        }
        else
        {
            int[] value = new int[4];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = 0;
            }
            return new ScoreData(value);
        }
    }
}
