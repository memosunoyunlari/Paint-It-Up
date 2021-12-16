using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{

    [SerializeField] [Range(15, 45)] float rotationSpeed;
    [SerializeField] [Range(-5, 5)] float moveDistance;
    [SerializeField] [Range(0.1f, 2)] float moveSpeed;

    [SerializeField] bool left;
    [SerializeField] bool right;

    Vector3 targetPos;
    Vector3 startPos;

    private void Awake()
    {
        if(left) targetPos = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);
        if(right) targetPos = new Vector3(transform.position.x - moveDistance, transform.position.y, transform.position.z);
        startPos = transform.position;
    }

    void Update()
    {
        rotateTheHorizontal();

        moveHorizontal();

    }

    private void moveHorizontal()
    {
        transform.position = Vector3.Lerp(startPos, targetPos, Mathf.PingPong(Time.time * moveSpeed, 1));

    }

    private void rotateTheHorizontal()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
