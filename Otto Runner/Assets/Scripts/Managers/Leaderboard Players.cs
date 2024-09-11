using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class LeaderboardPlayers
{
    private string namee;
    private float score;

    public float Score { get => score; set => score = value; }
    public string Namee { get => namee; set => namee = value; }

    public LeaderboardPlayers(string name, float score)
    {
        this.namee = name;
        this.score = score;
    }
}
