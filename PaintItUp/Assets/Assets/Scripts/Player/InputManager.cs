using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{

    Vector2 horizontalInputValue;


    MovementManager movementManager;
    private void Awake()
    {
        movementManager = GetComponent<MovementManager>();
    }
    void Update()
    {

        horizontalInputValue = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        movementManager.swerveInputValue = horizontalInputValue.x;



        if (Input.GetAxis("Horizontal") != 0)
        {
            movementManager.swerve = true;
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            movementManager.swerveVelocity = 0;
        }

    }

}

