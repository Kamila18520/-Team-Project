using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool isLevel;
    [SerializeField] string levelName;
    [SerializeField] int levelNumber;
    [SerializeField] GameManager gameManager;

    public GameObject Gate;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gracz wszed³ w collider");
        if (other.gameObject.CompareTag("Player") && !isLevel)
        {
            Debug.Log("Gracz wszedl do levelu " + levelName);
            gameManager.EntryLevel(levelNumber);

            SceneManager.LoadScene(levelNumber);
            //Invoke("ToLevel", 0.1f);

        }
        else if(other.gameObject.CompareTag("Player") && isLevel)
        {
            Debug.Log("Gracz wróci³ do lobby " + levelName);
            SceneManager.LoadScene(0);
        }
    }

    private void ToLevel()
    {
        SceneManager.LoadScene(levelNumber);

    }


}
