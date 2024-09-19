using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    public float playerSpeed = 15f;
    private float distance = 6000f;
    private float highscore;
    public TMP_Text distanceText;
    public TMP_Text highscoreText;

    public float Highscore { get => highscore; set => highscore = value; }

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("Highscore", 0f);
        UpdateHighscoreUI();
    }

    void Update()
    {
        if (!GameManger.instance.Dead)
        {
            distance += playerSpeed * Time.deltaTime;
            distanceText.text = "Distance: " + distance.ToString("F2") + "m";
        }
        if (distance > highscore)
        {
            GameManger.instance.IsLeaderboard = true;
            highscore = distance;
            PlayerPrefs.SetFloat("Highscore", highscore);
            PlayerPrefs.Save();
            UpdateHighscoreUI();
        }
    }

    public float GetDistance()
    {
        return distance;
    }

    void UpdateHighscoreUI()
    {
        highscoreText.text = "Highscore: " + highscore.ToString("F2") + "m";
    }
}
