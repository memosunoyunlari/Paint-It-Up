using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementManager : MonoBehaviour
{
    private CharacterController characterController;
    
    //main condition
    public bool mainMovementCondition;

    // forward movement variables
    [SerializeField] [Range(0.1f, 1f)] float forwardAccelerationSpeed;
    [SerializeField] [Range(0.1f, 0.3f)] float swerveAccelerationSpeed;
    public float forwardVelocity;
    
    //swerve variables
    public float swerveVelocity;
    public float swerveInputValue;
    public bool swerve;

    

    //backward movement variables
    [SerializeField] [Range(0.25f, 1.5f)] float decelatartionSpeed;
    [SerializeField] LayerMask deceleratorGround;

    //vertical movement variables
    public float verticalVelocity;
    public float gravity = -9.81f;
    
    //max speed setters
    public bool firstLimit;
    public bool secondLimit;

    //rotating platform variables
    [SerializeField] LayerMask leftRotatorGround;
    [SerializeField] LayerMask rightRotatorGround;
    float leftRotatorSpeed;
    float rightRotatorSpeed;

    // final vector
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

        Debug.Log(forwardVelocity);

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




