using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BossTrapController : MonoBehaviour
{
    [SerializeField] int levelsFinished=0;

    [Header("Boss Trap")]
    [SerializeField] GameObject[] BossTrap;

    [Header("Boss")]
    public BossController BossController;

    [Header("EndGameAnimation")]
    public GameObject EndTimeline;

    private bool end = false;
    public void FinishLevel()
    {
        levelsFinished++;
        Debug.Log("Level " +levelsFinished + " Finished");

        foreach(GameObject go in BossTrap) 
        { 
        StartCoroutine(MoveTrapDown(go));
        }
        
        if (levelsFinished==3)
        {
            Invoke("FinishBossLevel",9.5f);
        }
    }

    IEnumerator MoveTrapDown(GameObject Trap)
    {
        yield return new WaitForSeconds(6f); // OpóŸnienie o 2 sekundy

        Vector3 startPosition = Trap.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y -1, startPosition.z);

        float elapsed = 0f;
        float duration = .2f;

        while (elapsed < duration)
        {
            Trap.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Upewnij siê, ¿e obiekt jest dok³adnie na docelowej pozycji po zakoñczeniu przesuwania.
        Trap.transform.position = targetPosition;
    }


    public void FinishBossLevel()
    {
        BossController.isFinishEntireLevel = true;
        BossController.StopBattleMode();
        EndTimeline.SetActive(true);
        Debug.Log("Boss Level Finished");
        float time = (float)EndTimeline.GetComponent<PlayableDirector>().duration;
        Invoke("LobbyLevel", time);
    }
    private void LobbyLevel()
    {
        Debug.Log("Zakoñczona Gra. Gracz przeniesiony do lobby");
        end = true;

    }

    private void Update()
    {
        if(end)
        {
            SceneManager.LoadScene(0);

        }
    }
}
