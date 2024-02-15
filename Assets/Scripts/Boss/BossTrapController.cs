using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrapController : MonoBehaviour
{
    [SerializeField] int levelsFinished=0;

    [Header("Boss Trap")]
    [SerializeField] GameObject[] BossTrap;

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
            FinishBossLevel();
        }
    }

    IEnumerator MoveTrapDown(GameObject Trap)
    {
        yield return new WaitForSeconds(6f); // Op�nienie o 2 sekundy

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

        // Upewnij si�, �e obiekt jest dok�adnie na docelowej pozycji po zako�czeniu przesuwania.
        Trap.transform.position = targetPosition;
    }


    private void FinishBossLevel()
    {
        Debug.Log("Boss Level Finished");
    }
}
