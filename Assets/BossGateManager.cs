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
        Gate.SetActive(false);
        for(int i=0; i <=2; i++) 
        {
            Crystals[i].SetActive(false);
        
        }
    }


    public void FinishLvl()
    {
        Crystals[FinishedLvls].SetActive(true);
        FinishedLvls++;

        if(FinishedLvls==3) 
        {

            OpenGate();
        
        }
    }

    public void OpenGate()
    {
        Gate.SetActive(true);
    }
}
