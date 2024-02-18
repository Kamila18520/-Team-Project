using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBossController : MonoBehaviour
{
    [SerializeField] bool Enter = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && Enter)
        {
            SceneManager.LoadScene(4);
        }
    }

}
