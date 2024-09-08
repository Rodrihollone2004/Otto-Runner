using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    public float playerSpeed = 15f;
    private float distance = 0f;
    private float highscore = 0f;
    public TMP_Text distanceText;
    public TMP_Text highscoreText;

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("Highscore", 0f);
        UpdateHighscoreUI();
    }

    void Update()
    {
        distance += playerSpeed * Time.deltaTime;

        distanceText.text = "Distance: " + distance.ToString("F2") + "m";

        if (distance > highscore)
        {
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
