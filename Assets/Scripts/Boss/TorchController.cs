using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TorchController : MonoBehaviour
{
    [SerializeField] BossTrapController TrapController;
    [SerializeField] GameObject AnimationDirector;
    public bool isPlayerInZone;
    public bool isFireOn = false;
    [SerializeField] GameObject FireEffect;
    [SerializeField] GameObject Light;

    [SerializeField] GameObject LetterE;

    [SerializeField] Rigidbody Chain;
    // Start is called before the first frame update
    void Start()
    {
        Light.SetActive(false);
        FireEffect.SetActive(false);
        LetterE.SetActive(false);
    }

     void Update()
    {

        if (isFireOn)
        {
            LetterE.SetActive(false);
        }
        else
        {
            LetterE.SetActive(isPlayerInZone);
        }



        if (isPlayerInZone && !isFireOn && Keyboard.current.eKey.wasReleasedThisFrame) 
        {
            Debug.Log("Player pressed E key");
            TrapController.FinishLevel();
            isFireOn = true;
            Light.SetActive(true);
            FireEffect.SetActive(true);
            AnimationDirector.SetActive(true);
            Chain.isKinematic = false;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("BOSS LEVEL: Player entered into torch trigger ");
            isPlayerInZone = true;

            LetterE.transform.LookAt(other.transform.position);


        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("BOSS LEVEL: Player exit  into torch trigger ");
            isPlayerInZone = false;
        }



    }
}
