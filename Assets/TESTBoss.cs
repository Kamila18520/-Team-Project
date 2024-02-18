using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTBoss : MonoBehaviour
{
    [Header("End")]
    public bool end = false;
    [SerializeField] GameObject EndTimeline;
    [SerializeField] BossTrapController BossTrapController;

    [Header("Start")]
    public bool start = false;
    [SerializeField] GameObject StartTimeline;



    private void Update()
    {
        
        if(end)
        {
            StartTimeline.SetActive(false);
            EndTimeline.SetActive(true);
            BossTrapController.FinishBossLevel();
        }
        else if (start) 
        {

            StartTimeline.SetActive(true);
            EndTimeline.SetActive(false);

        }

    }
}
