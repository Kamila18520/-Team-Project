using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TorchController : MonoBehaviour
{
    [SerializeField] GameObject FireEffect;
    [SerializeField] GameObject LetterE;
    // Start is called before the first frame update
    void Start()
    {
        FireEffect.SetActive(false);
        LetterE.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("BOSS LEVEL: Player entered into torch trigger ");
            LetterE.SetActive(true);
            //Update(other.transform.rotation);
            LetterE.transform.LookAt(other.transform.position);

            if(Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("Player pressed E key");
                FireEffect.SetActive(true);
            }
        }
    }
}
