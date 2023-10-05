using System.IO;
using UnityEngine;

public class SaveAndLoadData
{
    public void SaveUser(DataUser dataUser)
    {
        var userData = new DataUser();
        userData.Name = dataUser.Name;

        string json = JsonUtility.ToJson(userData,true);
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
        else
        {
            return new DataUser();
        }
    }
}