using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LeaderboardData
{
    public List<LeaderboardPlayers> players;

    public LeaderboardData(List<LeaderboardPlayers> players)
    {
        this.players = players;
    }
}
