using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera followingCam;
    [SerializeField] CinemachineVirtualCamera climbingCam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ClimbingCamOn"))
        {
            followingCam.Priority = 9;
            climbingCam.Priority = 10;
            transform.rotation = Quaternion.Euler(new Vector3(-10,0,0));
        }
    }




}
