using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevels(ClearedLevelsData clearedLevelsData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/levels.heh";
        string path = Path.Combine(Application.persistentDataPath, "save.heh");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, clearedLevelsData);
        Debug.Log ("Creating save in " + path);
        stream.Close();
    }

    public static ClearedLevelsData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "save.heh");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           ClearedLevelsData data = formatter.Deserialize(stream) as ClearedLevelsData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
