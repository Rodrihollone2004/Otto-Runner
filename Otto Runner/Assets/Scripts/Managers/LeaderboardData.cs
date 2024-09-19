using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeaderboardData
{
    public List<LeaderboardPlayers> players;

    public LeaderboardData(List<LeaderboardPlayers> playersList)
    {
        this.players = playersList;
    }
}
