using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public class ShopItem
    {
        public string itemName;
        public int itemPrice;
        public bool isPurchased = false;  
    }

    [SerializeField]private ShopItem[] itemsForSale; 
    [SerializeField]private GameObject[] purchaseButtons;  

    private int totalCoins;

    void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        UpdateShopUI();
    }

    public void BuyItem(int index)
    {
        if (itemsForSale[index].isPurchased)
        {
            Debug.Log("Item ya comprado.");
            return;
        }

        if (totalCoins >= itemsForSale[index].itemPrice)
        {
            totalCoins -= itemsForSale[index].itemPrice;
            itemsForSale[index].isPurchased = true;

            PlayerPrefs.SetInt("TotalCoins", totalCoins);
            PlayerPrefs.SetInt(itemsForSale[index].itemName, 1);  
            PlayerPrefs.Save();

            UpdateShopUI();
            Debug.Log("Item comprado: " + itemsForSale[index].itemName);
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
        }
    }

    private void UpdateShopUI()
    {
        for (int i = 0; i < itemsForSale.Length; i++)
        {
            if (itemsForSale[i].isPurchased)
            {
                purchaseButtons[i].GetComponent<Button>().interactable = false;
                purchaseButtons[i].GetComponentInChildren<TMP_Text>().text = "Comprado";
            }
            else
            {
                purchaseButtons[i].GetComponent<Button>().interactable = true;
                purchaseButtons[i].GetComponentInChildren<TMP_Text>().text = "Comprar (" + itemsForSale[i].itemPrice + " monedas)";
            }
        }
    }
}
