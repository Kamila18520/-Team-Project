using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTorchAnimationController : MonoBehaviour
{
    
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] GameObject Track;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera.transform.SetPositionAndRotation(MainCamera.transform.position, Quaternion.Euler(0, 0, 0));

      ///  CinemachineSmoothPath smoothPath = Track.GetComponent<CinemachineSmoothPath>();

    }


}
