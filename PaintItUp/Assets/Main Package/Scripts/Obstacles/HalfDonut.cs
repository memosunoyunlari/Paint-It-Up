using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    [SerializeField] GameObject stick;

    [SerializeField] [Range(0.1f,1.5f)] float reachRange;

    [SerializeField] [Range(0.25f, 1.5f)] float reachSpeed;

    

    private Vector3 currentPos;
    private Vector3 targetPos;

    

    private void Awake()
    {
        stick.transform.localPosition = currentPos;

        targetPos = new Vector3(currentPos.x - reachRange, currentPos.y, currentPos.z);

        
        

    }

    private void Update()
    {
        stick.transform.localPosition = Vector3.Lerp(currentPos, targetPos, Mathf.PingPong(Time.time * reachSpeed, 1));
    }

    
}
