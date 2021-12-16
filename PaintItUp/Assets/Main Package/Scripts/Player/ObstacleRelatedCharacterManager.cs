using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ObstacleRelatedCharacterManager : MonoBehaviour
{
    PaintingSystem paintSystem;
    MovementManager moveManager;

    private Vector3 startPos;

    //startRotation for resetting
    Quaternion startRotation;

    [SerializeField] CinemachineVirtualCamera follow;
    [SerializeField] CinemachineVirtualCamera climb;

    private bool first;

    private void Update()
    {
        if (transform.position.y < -20)
        {
            ResetPlayer();
        }
    }


    private void Start()
    {
        startPos = transform.position;
        moveManager = GetComponent<MovementManager>();
        paintSystem = GetComponent<PaintingSystem>();

        startRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        first = true;
    }

    

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == ("obstacle") && first)
        {

            ResetPlayer();
            StartCoroutine("firstTimer");

        }
        else
        {

            return;
        }



    }

    IEnumerator firstTimer()
    {
        first = false;
        yield return new WaitForSeconds(0.7f);
        first = true;
    }
    

    

    private void ResetPlayer()
    {
        transform.position = startPos;
        moveManager.forwardVelocity = 0;
        moveManager.swerveVelocity = 0;
        moveManager.verticalVelocity = 0;
        transform.position = startPos;
        transform.position = startPos;

        follow.Priority = 11;
        climb.Priority = 9;

        transform.rotation = startRotation;

        paintSystem.paintAmount--;
    }
}
