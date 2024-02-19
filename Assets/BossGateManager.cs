using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGateManager : MonoBehaviour
{   
    
    public int FinishedLvls = 0;

    [Header("Crystals")]
    public GameObject[] Crystals = new GameObject[3];


    [Header("Gate")]
    [SerializeField] GameObject Gate;

    private void Start()
    {
      //  Gate.SetActive(false);

    }




    public void OpenGate()
    {
        Debug.Log("Otworzono portal do bossa");
        Gate.SetActive(true);
    }
}
