using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TorchController : MonoBehaviour
{
    public bool isPlayerInZone;
    public bool isFireOn = false;
    [SerializeField] GameObject FireEffect;
    [SerializeField] GameObject Light;

    [SerializeField] GameObject LetterE;
    // Start is called before the first frame update
    void Start()
    {
        Light.SetActive(false);
        FireEffect.SetActive(false);
        LetterE.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("BOSS LEVEL: Player entered into torch trigger ");
            isPlayerInZone = true;

            LetterE.SetActive(true);
            //Update(other.transform.rotation);
            LetterE.transform.LookAt(other.transform.position);

            if(Keyboard.current.eKey.wasPressedThisFrame && !isFireOn)
            {
                Debug.Log("Player pressed E key");
                isFireOn= true;
                Light.SetActive(true);
                FireEffect.SetActive(true);
            }
        }
        else
        {
            isPlayerInZone= false;
        }
    }
}
