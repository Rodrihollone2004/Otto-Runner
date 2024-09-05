using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public TMP_Text coinsText;

    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        coinsText.text = "Coins: " + totalCoins.ToString();
    }
}
