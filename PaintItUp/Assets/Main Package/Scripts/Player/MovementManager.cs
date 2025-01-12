﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementManager : MonoBehaviour
{
    private CharacterController characterController;
    
    //main condition
    public bool mainMovementCondition;

    // forward movement variables
    [Header("Forward Movement Variables")]
    [SerializeField] [Range(0.1f, 1f)] float forwardAccelerationSpeed;
    
    public float forwardVelocity;

    //swerve variables
    [Header("Swerve Variables")]
    [SerializeField] [Range(0.1f, 0.3f)] float swerveAccelerationSpeed;
    public float swerveVelocity;
    public float swerveInputValue;
    public bool swerve;

    //backward movement variables
    [Header("Deceleration Variables")]
    [SerializeField] [Range(0.25f, 1.5f)] float decelatartionSpeed;
    [SerializeField] LayerMask deceleratorGround;

    //vertical movement variables
    [Header("Vertical Velocity Variables")]
    public float verticalVelocity;
    public float gravity = -9.81f;

    //max speed setters
    [Header("Speed Limit Variables")]
    public bool firstLimit;
    public bool secondLimit;

    //rotating platform variables
    [Header("Rotating Platform Related Movement Variables")]
    [SerializeField] LayerMask leftRotatorGround;
    [SerializeField] LayerMask rightRotatorGround;
    float leftRotatorSpeed;
    float rightRotatorSpeed;

    // final vector
    [Header("Final Movement Vector")]
    public Vector3 velocityVectors;

    void Awake()
    {
       
        characterController = GetComponent<CharacterController>();
        mainMovementCondition = true;
        firstLimit = true;
        secondLimit = false;
        
    }



    void Update()
    {
        
        

        // the forward velocity and related accerelation
        forwardVelocity += forwardAccelerationSpeed * Time.deltaTime;

        if(firstLimit) forwardVelocity = Mathf.Clamp(forwardVelocity, 0.1f, 8f);
        if (secondLimit)
        {
            forwardVelocity = Mathf.Clamp(forwardVelocity, 0.1f, 3f);
            forwardVelocity = 3f;
        }


        if (swerve)
        {
            swerveVelocity += swerveAccelerationSpeed;
            swerveVelocity = Mathf.Clamp(swerveVelocity, 0.1f, 2f);
        }

        if(rightRotatingPlatform())
        {
            rightRotatorSpeed = 1.3f;
        }
        else
        {
            rightRotatorSpeed = 0;
        }

        if (leftRotatingPlatform())
        {
            leftRotatorSpeed = -1.3f;
        }
        else
        {
            leftRotatorSpeed = 0;
        }



        if (decelerator())
        {
            forwardVelocity += -decelatartionSpeed * Time.deltaTime;
            
        }

        // the gravital and vertical velocity part
        verticalVelocity += gravity * Time.deltaTime;
        if (characterController.isGrounded && verticalVelocity < 0) verticalVelocity = -2.0f;


        // the sum part of the repeated movement process
        velocityVectors = new Vector3((swerveInputValue * swerveVelocity + (rightRotatorSpeed + leftRotatorSpeed)) * Time.deltaTime, verticalVelocity * Time.deltaTime, forwardVelocity * Time.deltaTime);

        

        if (mainMovementCondition) characterController.Move(velocityVectors);

    }

    bool decelerator()
    {
       return Physics.Raycast(transform.position, Vector2.down, 2f, deceleratorGround);
    }

    bool leftRotatingPlatform()
    {
        return Physics.Raycast(transform.position, Vector2.down, 5f, leftRotatorGround);
    }

    bool rightRotatingPlatform()
    {
        return Physics.Raycast(transform.position, Vector2.down, 5f, rightRotatorGround);
    }


    //boostpad trigger
    private void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag("boostpad"))
        {
            
            forwardVelocity = 8f;
        }
        
    }
}




