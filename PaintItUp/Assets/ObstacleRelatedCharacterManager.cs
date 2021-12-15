using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ObstacleRelatedCharacterManager : MonoBehaviour
{
    MovementManager moveManager;

    private Vector3 startPos;

    //startRotation for resetting
    Quaternion startRotation;

    [SerializeField] CinemachineVirtualCamera follow;
    [SerializeField] CinemachineVirtualCamera climb;

    

    private void Awake()
    {
        startPos = transform.position;
        moveManager = GetComponent<MovementManager>();

        startRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("obstacle"))
        {
            transform.position = startPos;
            moveManager.forwardVelocity = 0;
            moveManager.swerveVelocity = 0;
            moveManager.verticalVelocity = 0;

            follow.Priority = 10;
            climb.Priority = 9;

            transform.rotation = startRotation;
        }
    }




}
