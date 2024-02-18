using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsGateController : MonoBehaviour
{
    [Header("NumerSceny")]
    [SerializeField] string withLevel = "[Wpisz nazwê poziomu]";
    [SerializeField] int SceneNumber = 0;

    private bool Enter = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Enter)
        {

            Debug.Log("Zaladowano scene: [" + withLevel + "] numer: " + SceneNumber);
            SceneManager.LoadScene(SceneNumber);
        }
    }
}
