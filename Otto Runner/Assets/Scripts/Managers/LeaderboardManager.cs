using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] TMP_Text numberboardText;
    [SerializeField] TMP_Text nameboardText;
    [SerializeField] TMP_Text scoreboardText;
    [SerializeField] TMP_InputField playerNameInput;

    [SerializeField] private DistanceCounter distanceCounter;
    private List<LeaderboardPlayers> leaderboard;

    [SerializeField] GameObject gameObjectLeaderboard;

    private void Awake()
    {
        distanceCounter = FindObjectOfType<DistanceCounter>();
        leaderboard = new List<LeaderboardPlayers>();
    }

    public void AddPlayer()
    {
        string name = playerNameInput.text;
        float score = distanceCounter.Highscore;


        leaderboard.Add(new LeaderboardPlayers(name, score));
        SortLeaderboard();
        UpdateNumberboardDisplay();
        UpdateNameboardDisplay();
        UpdateScoreboardDisplay();
    }

    private void SortLeaderboard()
    {
        leaderboard.Sort((a, b) => b.Score.CompareTo(a.Score));
        if (leaderboard.Count > 10)
        {
            leaderboard = leaderboard.GetRange(0, 10);
        }
    }

    private void UpdateNumberboardDisplay()
    {
        numberboardText.text = "N°\n";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            numberboardText.text += $"{i + 1}\n";
        }
    }
    private void UpdateNameboardDisplay()
    {
        nameboardText.text = "Nombre\n";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            nameboardText.text += $"{leaderboard[i].name}\n";
        }
    }
    private void UpdateScoreboardDisplay()
    {
        scoreboardText.text = "Score\n";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            scoreboardText.text += $"{leaderboard[i].Score}\n";
        }
    }

    public void ExitLeaderboard()
    {
        GameManger.instance.IsLeaderboard = false;
        gameObjectLeaderboard.SetActive(false);
    }

    public void EnterLeaderboard()
    {
        gameObjectLeaderboard.SetActive(true);
    }
}
