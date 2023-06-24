using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int level;
    public int money;
    public int skinIndex;

    public PlayerData (Progress progress) {
        level = progress.level;
        money = progress.money;
        skinIndex = progress.skinIndex;
    }

    public PlayerData() {
        level = 0;
        money = 0;
        skinIndex = 0;
    }

}
