using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BossGateManager BossGateManager;
    [SerializeField] private int PlayerLevelPrefs;
    [SerializeField] GameObject PlayerLobby;

    [Header("START")]
    public bool TEST;
    public bool START = true;
    [SerializeField] GameObject StartTimeLine;

    [Header("Level 1")]
    public bool LEVEL1 = false;
    [SerializeField] Transform SpawnPointAfter1Lvl;
    [SerializeField] GameObject Dimond1;
    [SerializeField] GameObject Gate1;




    [Header("Level 2")]
    public bool LEVEL2 = false;
    [SerializeField] Transform SpawnPointAfter2Lvl;
    [SerializeField] GameObject Dimond2;
    [SerializeField] GameObject Gate2;




    [Header("Level 3")]
    public bool LEVEL3 = false;
    [SerializeField] Transform SpawnPointAfter3Lvl;
    [SerializeField] GameObject Dimond3;
    [SerializeField] GameObject Gate3;


    

    //private static GameManager instance;

    void Start()
    {

        
        Debug.Log("START LOBBY");
        PlayerLevelPrefs = PlayerPrefs.GetInt("LEVEL");
       
        int LEVEL = PlayerPrefs.GetInt("LEVEL");
        if (LEVEL != 0) 
        {
            START = false;
            Debug.Log("Lobby entry");
              EntryLevel(LEVEL);

        }


        if (TEST) 
        {
            PlayerPrefs.SetInt("LEVEL", 0);

            if (START)
            {
             START = false;

            }

        }
        else if(!TEST)
        {

           if (START)
           {
                PlayerPrefs.SetInt("LEVEL", 0);
                StartTimeLine.SetActive(true);
                START = false;

           }
        }

       





        
    }


    public void EntryLevel(int level)
    {
        Debug.Log("Entry "+level);
        PlayerPrefs.SetInt("LEVEL", level);

        switch (level)
        {
            case 1:
                
                LEVEL1 = true;
                Debug.Log("Ustawiono level: " + LEVEL1);
                TeleportToLobby(level);
                break;

            case 2:
                LEVEL2 = true;
                Debug.Log("Ustawiono level: " + LEVEL2);
                TeleportToLobby(level);
                break;

            case 3:
                LEVEL3 = true;
                Debug.Log("Ustawiono level: " + LEVEL3);
                TeleportToLobby(level);
                break;

            default:
                // Domyœlny przypadek, jeœli ¿aden z powy¿szych przypadków nie pasuje
                Debug.LogError("Nieprawid³owy numer poziomu: " + level);
                break;
        }
    }

    public void TeleportToLobby(int level)
    {
        switch (level)
        {
            case 1:
                PlayerLobby.transform.position = SpawnPointAfter1Lvl.position;
                 Dimond1.SetActive(true);

                Gate1.SetActive(true);
                Gate2.SetActive(false);
                Gate3.SetActive(true);
                break;

            case 2:
                PlayerLobby.transform.position = SpawnPointAfter2Lvl.position;
                Dimond1.SetActive(true);
                Dimond2.SetActive(true);
                Gate2.SetActive(true);
                Gate3.SetActive(false);
                Gate1.SetActive(true);

                break;

            case 3:
                PlayerLobby.transform.position = SpawnPointAfter3Lvl.position;
                Dimond1.SetActive(true);
                Dimond2.SetActive(true);
                Dimond3.SetActive(true);
                Gate3.SetActive(true);
                Gate2.SetActive(true);
                Gate1.SetActive(true);
                BossGateManager.OpenGate();
                break;


            default:
                // Domyœlny przypadek, jeœli ¿aden z powy¿szych przypadków nie pasuje
                Debug.LogError("Nieprawid³owy numer poziomu: " + level);
                break;
        }
    }


}
