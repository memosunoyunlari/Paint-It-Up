using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical : MonoBehaviour
{

    private Vector3 startPos;
    private Vector3 targetPos;

    
    [SerializeField] [Range(0.5f,1.5f)] float moveDistance;
    [SerializeField] [Range(0.1f, 2)] float moveSpeed;

    private void Awake()
    {
        startPos = transform.position;

        targetPos = new Vector3(transform.position.x, transform.position.y - moveDistance, transform.position.z);
    }
    void Update()
    {
        transform.position = Vector3.Lerp(startPos, targetPos, Mathf.PingPong(Time.time * moveSpeed, 1));
    }
}
