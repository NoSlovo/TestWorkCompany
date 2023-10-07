using System.IO;
using UnityEngine;

public class SaveAndLoadData
{

    private string _defaultName = "Player";
    private int _defaultCount = 0;
    
    public void SaveUser(DataUser dataUser)
    {
        string json = JsonUtility.ToJson(dataUser);
        File.WriteAllText(Application.dataPath + "/UserDataFile.json",json);
    }

    public DataUser LoadUser()
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