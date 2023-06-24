using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour {

    public static Progress Instance { get; private set; }

    public int level;
    public int money;
    public int skinIndex;

    private void Awake() {
        if (Instance == null) { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);


        PlayerData playerData = SaveSystem.LoadPlayer();
        level = playerData.level;
        money = playerData.money;
        skinIndex = playerData.skinIndex;
    }

    public void Save() {
        PlayerData playerData = new PlayerData(this);
        SaveSystem.SavePlayer(playerData);
    }

}
