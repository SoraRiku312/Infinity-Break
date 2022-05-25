
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SaveGame()
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.idk";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData();


        
        
        formatter.Serialize(stream, data);
        stream.Close();

    }
    
    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/save.idk";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            if (stream.Length == 0)
                return null;
            stream.Position = 0;
            GameData data = formatter.Deserialize(stream) as GameData;
            
            return data;
            
        }
        
        {
            Debug.Log("Save file not found");
            return null;
        }
    }

}
