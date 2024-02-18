using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerLobby;

    [Header("START")]
    public bool START = true;
    [SerializeField] GameObject StartTimeLine;

    [Header("Level 1")]
    public bool LEVEL1 = false;
    [SerializeField] Transform SpawnPointAfter1Lvl;




    [Header("Level 2")]
    public bool LEVEL2 = false;
    [SerializeField] Transform SpawnPointAfter2Lvl;




    [Header("Level 3")]
    public bool LEVEL3 = false;
    [SerializeField] Transform SpawnPointAfter3Lvl;



    private static GameManager instance;

    void Start()
    {

        // SprawdŸ, czy istnieje ju¿ instancja GameManager
        if (instance != null)
        {
            // Zniszcz tê instancjê, poniewa¿ ju¿ istnieje GameManager
            Destroy(gameObject);
            return;
        }

        // Ustaw aktualn¹ instancjê jako instancjê GameManager
        instance = this;

        if (START)
        {
            StartTimeLine.SetActive(true);
            START = false;
        }

        DontDestroyOnLoad(gameObject);
    }


    public void EntryLevel(int level)
    {
        switch (level)
        {
            case 1:
                LEVEL1 = true;

                break;

            case 2:
                LEVEL2 = true;
                break;

            case 3:
                LEVEL3 = true;
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

                break;

            case 2:
                PlayerLobby.transform.position = SpawnPointAfter2Lvl.position;
                break;

            case 3:
                PlayerLobby.transform.position = SpawnPointAfter3Lvl.position;
                break;


            default:
                // Domyœlny przypadek, jeœli ¿aden z powy¿szych przypadków nie pasuje
                Debug.LogError("Nieprawid³owy numer poziomu: " + level);
                break;
        }
    }


}
