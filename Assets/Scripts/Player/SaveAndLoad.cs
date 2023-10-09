using System.IO;
using UnityEngine;

public class SaveAndLoad
{
    private const string _defaultName = "Player";
    private const int _defaultCount = 0;
    
    public void SaveData(DataUser dataUser)
    {
        string json = JsonUtility.ToJson(dataUser);
        File.WriteAllText(Application.dataPath + "/UserDataFile.json",json);
    }

    public DataUser LoadData()
    {
        if (File.Exists(Application.dataPath + "/UserDataFile.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/UserDataFile.json");
            DataUser dataUser = JsonUtility.FromJson<DataUser>(json);
            return dataUser;   
        }

        var data = new DataUser();
        data.Name = _defaultName;
        data.Coin = _defaultCount;
        
        return data ;
    }
}