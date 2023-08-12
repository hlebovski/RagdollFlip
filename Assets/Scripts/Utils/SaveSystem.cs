using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

public static class SaveSystem {

    public static void SavePlayer(PlayerData playerData) {

        string JSON = JsonUtility.ToJson(playerData, true);
        PlayerPrefs.SetString("Data", JSON);
        Debug.Log(JSON);
    }

    public static PlayerData LoadPlayer() {
        //string path = Application.persistentDataPath + "player.sav";
        

        if(PlayerPrefs.HasKey("Data")) {
            string JSON = PlayerPrefs.GetString("Data");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(JSON);
            return playerData;

        } else {
            return new PlayerData();
        }


    }

}
