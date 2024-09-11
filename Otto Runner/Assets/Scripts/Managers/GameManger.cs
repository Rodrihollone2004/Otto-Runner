using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    LeaderboardManager leaderboardManager;
    private bool isLeaderboard = false;
    private bool dead = false;

    public bool Dead { get => dead; set => dead = value; }
    public bool IsLeaderboard { get => isLeaderboard; set => isLeaderboard = value; }
    public LeaderboardManager LeaderboardManager { get => leaderboardManager; set => leaderboardManager = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
