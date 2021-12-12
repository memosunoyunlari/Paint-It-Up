using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementManager : MonoBehaviour
{


    public bool mainMovementCondition;


    private CharacterController characterController;

    [SerializeField] [Range(0.1f, 0.5f)] float forwardAccelerationSpeed;
    [SerializeField] [Range(0.1f, 0.2f)] float swerveAccelerationSpeed;
    private float forwardVelocity;

    public float swerveVelocity;
    public float swerveInputValue;
    public bool swerve;

    private float verticalVelocity;
    private float gravity = -9.81f;
    [SerializeField] LayerMask platformMask;

    Vector3 velocityVectors;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        mainMovementCondition = true;

    }



    void Update()
    {


        // the forward velocity and related accerelation
        forwardVelocity += forwardAccelerationSpeed * Time.deltaTime;
        forwardVelocity = Mathf.Clamp(forwardVelocity, 0.1f, 5f);

        if (swerve)
        {
            swerveVelocity += swerveAccelerationSpeed;
            swerveVelocity = Mathf.Clamp(swerveVelocity, 0.1f, 0.8f);
        }


        // the gravital and vertical velocity part
        verticalVelocity += gravity * Time.deltaTime;
        if (characterController.isGrounded && verticalVelocity < 0) verticalVelocity = -2.0f;


        // the sum part of the repeated movement process
        velocityVectors = new Vector3(swerveInputValue * swerveVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, forwardVelocity * Time.deltaTime);
        if (mainMovementCondition) characterController.Move(velocityVectors);

    }


}




