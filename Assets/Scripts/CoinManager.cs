using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI coinsText;
    public int coinsToCollect = 10; 

    private int coinsCollected = 0;

    void Start()
    {
       
        CoinController.CoinCollectedEvent += UpdateCoinsText;

        
        UpdateCoinsUIText();
    }

    
    void UpdateCoinsText(int collectedCoins)
    {
        coinsCollected = collectedCoins;
        UpdateCoinsUIText();
    }

    void UpdateCoinsUIText()
    {
        coinsText.text = "Coins: " + coinsCollected + " / " + coinsToCollect;
    }

   
    public void UpdateCollectedCoinsText(int amount)
    {
        coinsCollected += amount;
        UpdateCoinsUIText();
    }

    
    void OnDestroy()
    {
        CoinController.CoinCollectedEvent -= UpdateCoinsText;
    }
}
