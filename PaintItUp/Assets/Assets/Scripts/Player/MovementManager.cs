using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementManager : MonoBehaviour
{


    public bool mainMovementCondition;


    private CharacterController characterController;

    [SerializeField] [Range(0.1f, 1f)] float forwardAccelerationSpeed;
    [SerializeField] [Range(0.1f, 0.3f)] float swerveAccelerationSpeed;
    private float forwardVelocity;

    [SerializeField] [Range(0.25f, 1.5f)] float decelatartionSpeed;
    

    public float swerveVelocity;
    public float swerveInputValue;
    public bool swerve;

    private float verticalVelocity;
    private float gravity = -9.81f;
    [SerializeField] LayerMask deceleratorGround;

    Vector3 velocityVectors;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        mainMovementCondition = true;

    }



    void Update()
    {
        //if(Physics.Raycast(transform.position, Vector2.down, 2f, deceleratorGround))
        //{
        //    decelerator = true;
            
        //}
        //else
        //{
        //    decelerator = false;
        //}
        

        // the forward velocity and related accerelation
        forwardVelocity += forwardAccelerationSpeed * Time.deltaTime;
        forwardVelocity = Mathf.Clamp(forwardVelocity, 0.1f, 5f);

        if (swerve)
        {
            swerveVelocity += swerveAccelerationSpeed;
            swerveVelocity = Mathf.Clamp(swerveVelocity, 0.1f, 1.6f);
        }

        if(decelerator())
        {
            forwardVelocity += -decelatartionSpeed * Time.deltaTime;
            
        }

        // the gravital and vertical velocity part
        verticalVelocity += gravity * Time.deltaTime;
        if (characterController.isGrounded && verticalVelocity < 0) verticalVelocity = -2.0f;


        // the sum part of the repeated movement process
        velocityVectors = new Vector3(swerveInputValue * swerveVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, forwardVelocity * Time.deltaTime);

        Debug.Log(forwardVelocity);

        if (mainMovementCondition) characterController.Move(velocityVectors);

    }

    bool decelerator()
    {
       return (Physics.Raycast(transform.position, Vector2.down, 2f, deceleratorGround));
    }
}




