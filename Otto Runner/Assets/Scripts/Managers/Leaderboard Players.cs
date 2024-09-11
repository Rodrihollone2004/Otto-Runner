using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPlayers : MonoBehaviour
{
    private string name;
    private float score;

    public float Score { get => score; set => score = value; }
    public string Name { get => name; set => name = value; }

    public LeaderboardPlayers(string name, float score)
    {
        this.name = name;
        this.score = score;
    }
}
