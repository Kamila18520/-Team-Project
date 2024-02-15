using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    
    [SerializeField] Transform player;
    [SerializeField] Transform Eye;

    [Header("Attack")]

    [SerializeField] GameObject AttactTarget;
    [SerializeField] GameObject Attack;
    public bool inBattleMode = true;
    public bool isAttacking = false;
    [SerializeField] float AttackDutarion;


    private void Start()
    {
        Attack.SetActive(true);
        AttactTarget.SetActive(false);
        StartCoroutine(RepeatAction());
    }

    void Update()
    {
        if(!isAttacking) 
        { 
        Eye.transform.LookAt(player);
       // AttactTarget.transform.position = player.position;
        }

        
        
    }

    public void StartBattleMode()
    {
        inBattleMode = true;
        Debug.Log("Ballte mode enabled");

        StartCoroutine(RepeatAction());

    }

    public void StopBattleMode()
    {
        inBattleMode = false;
        Attack.SetActive(false);
        StopAllCoroutines();
        Debug.Log("Ballte mode disabled");
    }





    IEnumerator RepeatAction()
    {
        while (inBattleMode)
        {
            PrepareForAttack();
            yield return new WaitForSeconds(4f);

            MainAttack();
            yield return new WaitForSeconds(3f);

            BreakBetweenAttacks();
            yield return new WaitForSeconds(5f);
        }
    }

    private void PrepareForAttack()
    {
        if(!Attack.activeSelf)
        {
            Debug.Log("BOSS: Prepare for Attack");
            Attack.SetActive(true);
        }

    }

    private void MainAttack()
    {
        Attack.SetActive(true);

        Debug.Log("BOSS: Main Attack");
        AttactTarget.SetActive(true);
        AttactTarget.transform.position = player.position;
        isAttacking = true;

    }

    private void BreakBetweenAttacks()
    {
        Debug.Log("BOSS: BreakBetweenAttack");
        isAttacking = false;
        AttactTarget.SetActive(false);

        Attack.SetActive(false);

    }


}
