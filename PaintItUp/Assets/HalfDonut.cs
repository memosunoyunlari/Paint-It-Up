using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    [SerializeField] GameObject stick;

    [SerializeField] [Range(0.5f,1.5f)] float reachRange;

    [SerializeField] [Range(0.25f, 1.5f)] float reachSpeed;

    private Vector3 currentPos;
    private Vector3 targetPos;

    

    private void Awake()
    {
        stick.transform.position = currentPos;
        targetPos = new Vector3(reachRange + currentPos.x, currentPos.y, currentPos.z);
    }

    private void Update()
    {
        stick.transform.position = Vector3.Lerp(currentPos, targetPos, Mathf.PingPong(Time.time * reachSpeed, 1));
    }
}
