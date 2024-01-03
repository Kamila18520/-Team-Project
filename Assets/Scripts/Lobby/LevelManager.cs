using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string levelName;
    [SerializeField] int levelNumber;

    public GameObject Gate;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gracz wszed³ w collider");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gracz wszedl do levelu " + levelName);
            SceneManager.LoadScene(levelNumber);

        }
    }


}
