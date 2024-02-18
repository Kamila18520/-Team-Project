using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UI;

public class BossAttackDamager : MonoBehaviour
{
    [Header("Player dead")]
    public CheckpointsController CheckpointsController;
    public DebugPlayerDeathPosition DebugPlayerDeathPosition;
    [SerializeField] GameObject PlayerInput;
    [SerializeField] GameObject MainCamera;

    [Header("Boss Attack damage")]
    public int Life = 3;
    [SerializeField] Transform AttackTarget;
    [SerializeField] GameObject panelImage;
    [SerializeField] GameObject DeadPanel;

    [SerializeField] float distance;
    public bool Damagable = true;
    private CapsuleCollider capsuleCollider;

    private void Start()
    {
        DeadPanel.SetActive(false);
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Damagable)
        {
            Life--;
            Debug.Log("Gracz zosta³ zraniony atakiem zadanym przez Bossa. Zosta³o ¿yæ: " + Life);
            StartCoroutine(FadePanelCoroutine());
            IsPlayerAlive();
        }
    }

    private void IsPlayerAlive()
    {
        if (Life <= 0)
        {
            // Zablokuj kursor myszy w centrum ekranu
            Cursor.lockState = CursorLockMode.Locked;



            PlayerInput.SetActive(false);
            DeadPanel.SetActive(true);
            DebugPlayerDeathPosition.SetDeathPosition();
            Debug.Log("Gracz umar³");
            float deathAnim = (float)DeadPanel.GetComponent<PlayableDirector>().duration;
            Invoke("PlayerDead", deathAnim);
        }
    }

    private void PlayerDead()
    {

        Debug.Log("Animacja œmierci zakoñczona");
        DeadPanel.SetActive(false);

        // SprawdŸ, czy CheckpointsController jest przypisany przed prób¹ ustawienia checkpointu
        if (CheckpointsController != null)
        {
            // Odblokuj kursor myszy
            Cursor.lockState = CursorLockMode.None;


            CheckpointsController.SetPlayerCheckpointPosition(CheckpointsController.CurrentCheckpoint);
            MainCamera.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            Debug.LogWarning("CheckpointsController nie jest przypisany. Przypisz go w Unity Editor.");
        }

        PlayerInput.SetActive(true);
    }

    private void Update()
    {
        gameObject.transform.LookAt(AttackTarget);
        distance = Vector3.Distance(gameObject.transform.position, AttackTarget.position);
        capsuleCollider.height = distance / 2;

        // Utwórz nowy obiekt Vector3 z odpowiednimi wspó³rzêdnymi
        Vector3 newCenter = capsuleCollider.center;
        newCenter.z = capsuleCollider.height / 2;

        // Przypisz nowy center do capsuleCollider
        capsuleCollider.center = newCenter;
    }

    IEnumerator FadePanelCoroutine()
    {
        panelImage.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        panelImage.SetActive(false);
    }
}
