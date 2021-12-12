using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{

    [SerializeField] [Range(15, 45)] float rotationSpeed;
    [SerializeField] [Range(0.5f, 5)] float moveDistance;

    [SerializeField] [Range(0.3f, 3)] float transitionTime;
    [SerializeField] bool midHorizontal;
    [SerializeField] bool leftHorizontal;
    [SerializeField] bool rightHorizontal;

    private Vector3 refSpeed = Vector3.zero;
    private Vector3 targetPos;
    
    void Update()
    {
        rotateTheHorizontal();

        if(leftHorizontal)
        {
            

            


        }

    }

    private void leftFirstMove()
    {
        
        
    
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref refSpeed, transitionTime);
        var currentPos = transform.position;
        if (currentPos == targetPos)
        {
            var targetPos = transform.position - new Vector3(moveDistance, 0, 0);
            leftSecondMove();
        }


    }

    private void leftSecondMove()
    {
        var targetPos = transform.position - new Vector3(moveDistance, 0, 0);
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref refSpeed, transitionTime);
        var currentPos = transform.position;
        if (currentPos == targetPos)
        {
            targetPos = transform.position + new Vector3(moveDistance, 0, 0);
            leftFirstMove();
        }
    }

    private void rotateTheHorizontal()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
