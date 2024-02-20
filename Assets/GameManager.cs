using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    [SerializeField] BossGateManager BossGateManager;
    [SerializeField] private int PlayerLevelPrefs;
    [SerializeField] GameObject PlayerLobby;

    [Header("First Entry")]

    private static bool FirstEntry = true;
    public bool FirstEntryRead;
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject Camera;

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


    [Header("End")]
    [SerializeField] GameObject EndTimeline;

    [Header("RepeatGame")]
    private static bool GameFinished = false;

    //private static GameManager instance;

    void Start()
    {
        if (!FirstEntry)
        {
            OnEnterClick();
        }
        else if(FirstEntry)
        {
            Camera.SetActive(true);
            MenuCanvas.SetActive(true);
        }
    }

    private void Update()
    {
        if (FirstEntry && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter wciœniêty. Gra siê rozpoczê³a");
            MenuCanvas.SetActive(false);
            Camera.SetActive(false);
            OnEnterClick();
           // Invoke("OnEnterClick", 0.2f);
        }

        if(GameFinished)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                PlayerPrefs.SetInt("LEVEL", 0);

                GameFinished = false;
                Debug.Log("Gracz rozpocz¹³ gre ponownie");
                SceneManager.LoadScene(0);
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameFinished=false;
                Debug.Log("Gracz wyszed³ z gry");
                QuitGame();
            }

        }
    }

    void QuitGame()
    {
        // Wy³¹czanie aplikacji
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


    private void OnEnterClick()
    {
        if (FirstEntry)
        {
            Debug.Log("Gracz wszed³ pierwszy raz na mape");
            FirstEntry = false;
            PlayerPrefs.SetInt("LEVEL", 0);
        }

        FirstEntryRead = FirstEntry;
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
            if (START)
            {
                START = false;

            }

        }
        else if (!TEST)
        {
            if (START)
            {
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

            case 4:
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

            case 4:
                PlayerLobby.SetActive(false);
                EndTimeline.SetActive(true);
                Invoke("GameFinishedClick", 2f);
                
                break;



            default:
                // Domyœlny przypadek, jeœli ¿aden z powy¿szych przypadków nie pasuje
                Debug.LogError("Nieprawid³owy numer poziomu: " + level);
                break;
        }
    }

    private void GameFinishedClick()
    {
        GameFinished = true;
    }


}
