using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZone : MonoBehaviour
{
    [SerializeField] private bool isReverseTrigger;
    [SerializeField]
    private float maxVolume;
    [SerializeField]
    private float minVolume;
    [SerializeField]
    private float fadeInDuration = 2.0f; // Czas, w którym dŸwiêk bêdzie stopniowo stawa³ siê g³oœniejszy



    private AudioSource audioSource;
    private float currentVolume = 0.0f;
    private bool fadingIn = false;
    private float destination;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = currentVolume;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isReverseTrigger)
        {
           
            AudioPlay();
        }
        else if (other.CompareTag("Player") && isReverseTrigger)
        {
            AudioStop();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isReverseTrigger)
        {
            AudioStop();
        }
        else if (other.CompareTag("Player") && isReverseTrigger)
        {
            AudioPlay();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isReverseTrigger)
        {
            Debug.Log("Player spawn into audioZone");
            audioSource.volume = maxVolume;
        }
        else if (other.CompareTag("Player") && isReverseTrigger)
        {
            Debug.Log("Player spawn out of audioZone");
            audioSource.volume = minVolume;

        }
    }


    private void AudioPlay()
    {
        Debug.Log("Player entered into audioZone");
        fadingIn = true;
        destination = maxVolume;
    }

    private void AudioStop()
    {
        Debug.Log("Player exit from audioZone");
        fadingIn = true;
        destination = minVolume;
        Update();
    }

    void Update( )
    {
        if (fadingIn)
        {
            // Interpolacja liniowa miêdzy obecn¹ g³oœnoœci¹ a maksymaln¹ g³oœnoœci¹
            currentVolume = Mathf.Lerp(currentVolume, destination, Time.deltaTime / fadeInDuration);

            // Ustaw now¹ g³oœnoœæ
            audioSource.volume = currentVolume;

            // Jeœli osi¹gniêto maksymaln¹ g³oœnoœæ, zakoñcz fading
            if (Mathf.Approximately(currentVolume, destination))
            {
                fadingIn = false;
            }
        }
    }

}
