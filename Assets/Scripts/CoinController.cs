using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int Coin = 0;

 


    private void OnTriggerEnter(Collider other)
    {

        Coin++;
        
        Debug.Log(Coin);
        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        
    }



}




