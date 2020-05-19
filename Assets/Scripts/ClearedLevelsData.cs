using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClearedLevelsData
{
    public Level[] Levels;

    public ClearedLevelsData(Level[] Levels)
    {
        this.Levels = Levels;
    }
}

[System.Serializable]
public class Level
{
   public int levelNumber;
   public bool cleared;
   public int hiScore;

    public Level(int levelNumber, bool cleared, int hiScore)
    {
        this.levelNumber = levelNumber;
        this.cleared = cleared;
        this.hiScore = hiScore;
    }
}
