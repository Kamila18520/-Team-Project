using System;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static event Action<int> CoinCollectedEvent; // Delegat i zdarzenie do przekazywania informacji o zebranych monetach
    public int collectedCoins = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            collectedCoins++;
            Debug.Log("Collected coins: " + collectedCoins);
            Destroy(other.gameObject);

            // Wywo³ujemy zdarzenie, gdy gracz zbiera monetê, przekazuj¹c iloœæ zebranych monet
            CoinCollectedEvent?.Invoke(collectedCoins);
        }
    }
}
