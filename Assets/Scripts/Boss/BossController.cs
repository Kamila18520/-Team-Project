using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform Eye;

    void Update()
    {
        Eye.transform.LookAt(player);
    }
}
