using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class LeaderboardPlayers
{
    public string Namee; 
    public float Score;

    public LeaderboardPlayers(string name, float score)
    {
        Namee = name;
        Score = score;
    }
}
