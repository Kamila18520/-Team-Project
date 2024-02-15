using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsController : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Checkpoints;
    public int CurrentCheckpoint;


    private void Start()
    {
        int childCount = transform.childCount;

        // Make sure there are child objects before attempting to assign them
        if (childCount > 0)
        {
            Checkpoints = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                // Assign each child object to the Checkpoints array
                Checkpoints[i] = transform.GetChild(i).gameObject;
            }

            // Set the initial checkpoint
            SetCheckpoint(0);
        }
        else
        {
            Debug.LogWarning("Brak punktów kontrolnych. Dodaj punkty kontrolne jako dzieci tego obiektu.");
        }


    }


    public void SetCheckpoint(int point)
    {

        CurrentCheckpoint= point;
        Debug.Log("Ustawiono nowy checkpoint: " + CurrentCheckpoint);
    }

    public void SetPlayerCheckpointPosition(int point)
    {
        Player.transform.position = Checkpoints[point].transform.position;
        Debug.Log("Ustawiono gracza na pozycje checkpointa");

    }
}
