using UnityEngine;
using System;

[Serializable]
public class GameData 
{
    // Settings
    public int  difficultyLevel;
    public bool backgrounds;   

    // Stats
    public int highScore;
    public int highLevel;
    public int WordsCompleted;
    public int ErrorInputs;

    // Trophies
    public bool j;
    public static bool jf;

}
