using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBossController : MonoBehaviour
{
    [SerializeField] bool BossGate = false;
    [Header("NumerSceny")]
    [SerializeField] string withLevel= "[Wpisz nazwê poziomu]";
    private int SceneNumber = 0;

    [Header("Numer levelu 1/2/3/4")]
    [SerializeField] int LevelNumber;

    private bool Enter = true;




    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && Enter)
        {
            
            Debug.Log("Zaladowano scene: [" + withLevel+ "] numer: " + SceneNumber);
            //GameManager.TeleportToLobby(LevelNumber);
            if(!BossGate)
            {
            SceneManager.LoadScene(SceneNumber);
            }
            else if(BossGate) 
            {
                SceneManager.LoadScene(LevelNumber);
            
            }

        }
    }

}
