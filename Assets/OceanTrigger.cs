using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanTrigger : MonoBehaviour
{
    public bool isOcean = true;
    public GameObject Point;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isOcean)
        {
            other.transform.position = Point.transform.position;
        }
    }

}
