using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MenuLeaderBoard : MonoBehaviour
{
    [SerializeField] TMP_Text numberboardText;
    [SerializeField] TMP_Text nameboardText;
    [SerializeField] TMP_Text scoreboardText;

    //[SerializeField] private TMP_Text textToDisable1;
    //[SerializeField] private TMP_Text textToDisable2;
    //[SerializeField] private TMP_Text textToDisable3;
    //[SerializeField] private TMP_Text textToDisable4;
    //[SerializeField] private Button buttonToDisable;

    private List<LeaderboardPlayers> leaderboard;

    [SerializeField] GameObject gameObjectLeaderboard;

    private const string leaderboardKey = "leaderboardData";

    private void Awake()
    {
        if (leaderboard == null)
            leaderboard = new List<LeaderboardPlayers>();

        LoadLeaderboard();
        SortLeaderboard();
        UpdateNumberboardDisplay();
        UpdateNameboardDisplay();
        UpdateScoreboardDisplay();
    }

    private void SortLeaderboard()
    {
        leaderboard.RemoveAll(player => player == null);

        if (leaderboard.Count > 0)
        {
            leaderboard.Sort((a, b) =>
            {
                if (a == null || b == null)
                {
                    return 0;
                }

                return b.Score.CompareTo(a.Score);
            });

            if (leaderboard.Count > 8)
            {
                leaderboard = leaderboard.GetRange(0, 8);
            }
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
        nameboardText.text = "Name\n";

        if (leaderboard != null)
        {
            for (int i = 0; i < leaderboard.Count; i++)
            {
                if (leaderboard[i] != null && !string.IsNullOrEmpty(leaderboard[i].Namee))
                {
                    nameboardText.text += $"{leaderboard[i].Namee}\n";
                }
            }
        }
    }

    private void UpdateScoreboardDisplay()
    {
        scoreboardText.text = "Score\n";

        if (leaderboard != null)
        {
            for (int i = 0; i < leaderboard.Count; i++)
            {
                if (leaderboard[i] != null)
                {
                    scoreboardText.text += $"{leaderboard[i].Score.ToString("F0")}\n";
                }
            }
        }
    }

    public void ExitLeaderboard()
    {
        //textToDisable1.gameObject.SetActive(true);
        //textToDisable2.gameObject.SetActive(true);
        //textToDisable3.gameObject.SetActive(true);
        //textToDisable4.gameObject.SetActive(true);
        //buttonToDisable.gameObject.SetActive(true);

        gameObjectLeaderboard.SetActive(false);
    }

    public void EnterLeaderboard()
    {
        //textToDisable1.gameObject.SetActive(false);
        //textToDisable2.gameObject.SetActive(false);
        //textToDisable3.gameObject.SetActive(false);
        //textToDisable4.gameObject.SetActive(false);
        //buttonToDisable.gameObject.SetActive(false);

        gameObjectLeaderboard.SetActive(true);
    }

    private void LoadLeaderboard()
    {
        if (PlayerPrefs.HasKey(leaderboardKey))
        {
            string json = PlayerPrefs.GetString(leaderboardKey);

            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);

            if (data != null && data.players != null)
            {
                leaderboard = data.players;
            }
            else
            {
                leaderboard = new List<LeaderboardPlayers>();
            }
        }
        else
        {
            leaderboard = new List<LeaderboardPlayers>();
        }
    }
}
