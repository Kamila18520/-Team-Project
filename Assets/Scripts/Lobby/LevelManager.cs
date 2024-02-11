using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool isLevel;
    [SerializeField] string levelName;
    [SerializeField] int levelNumber;

    public GameObject Gate;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gracz wszed� w collider");
        if (other.gameObject.CompareTag("Player") && !isLevel)
        {
            Debug.Log("Gracz wszedl do levelu " + levelName);
            SceneManager.LoadScene(levelNumber);

        }
        else if(other.gameObject.CompareTag("Player") && isLevel)
        {
            Debug.Log("Gracz wr�ci� do lobby " + levelName);
            SceneManager.LoadScene(0);
        }
    }


}
