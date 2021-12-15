using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ParkourRelatedSectionalManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera followingCam;
    [SerializeField] CinemachineVirtualCamera climbingCam;

    MovementManager moveManager;

    
    

    private void Awake()
    {
       moveManager = this.gameObject.GetComponent<MovementManager>();

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ClimbingCamOn"))
        {
            followingCam.Priority = 9;
            climbingCam.Priority = 10;
            //player rotation
            transform.rotation = Quaternion.Euler(new Vector3(-10,0,0));
        }

        if(other.CompareTag("RotatorCamOn"))
        {
            followingCam.Priority = 10;
            
            climbingCam.Priority = 9;
            //player rotation
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            //rotator part speed limit
            moveManager.firstLimit = false;
            moveManager.secondLimit = true;
        }
    }




}
