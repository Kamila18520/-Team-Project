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
        float startY = transform.position.y;
        float targetY = startY - 1.0f;
        float duration = 1.0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newY = Mathf.Lerp(startY, targetY, elapsedTime / duration);

            // Przesuñ obiekt w dó³
            Trap.transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Zapewnij, ¿e obiekt znajduje siê dok³adnie na docelowej pozycji
        Trap.transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }


    private void FinishBossLevel()
    {
        Debug.Log("Boss Level Finished");
    }
}
