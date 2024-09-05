using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private int totalCoins = 0;           
    public TMP_Text coinsText;            

    void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        UpdateCoinsUI();
    }

    public void AddCoin(int amount)
    {
        totalCoins += amount;

        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();

        UpdateCoinsUI();
    }

    void UpdateCoinsUI()
    {
        coinsText.text = "Coins: " + totalCoins;
    }
}
