using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerDeathPosition : MonoBehaviour
{
    [SerializeField] Transform PlayerPos;
    [SerializeField] Transform EllenPos;

    public Vector3 PlayerPosition;
    public Vector3 EllenPosition;
    public Vector3 NewPlayerPsition;


    private void Update()
    {
        gameObject.transform.position = EllenPos.position;
    }
    public void SetDeathPosition()
    {
        PlayerPosition = PlayerPos.position;
        EllenPosition = EllenPos.position;
        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {

        PlayerPos.position = transform.position;
        NewPlayerPsition = PlayerPos.position;
        SetEllenZeroPos();
    }
    private void SetEllenZeroPos()
    {
        EllenPos.position = Vector3.zero;
        Debug.Log("Ustawiono now¹ pozycjê player1: " + NewPlayerPsition);

    }


}
