using UnityEngine;
using TMPro; 
public class HighscoreDisplay : MonoBehaviour
{
    public TMP_Text highscoreText;  

    void Start()
    {
        float highscore = PlayerPrefs.GetFloat("Highscore", 0f);

        highscoreText.text = "Highscore: " + highscore.ToString("F2") + "m";
    }
}