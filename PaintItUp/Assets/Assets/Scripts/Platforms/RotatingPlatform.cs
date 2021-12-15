using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] [Range(-45, 45)] float rotationSpeed;

    void Update()
    {
        transform.Rotate(0,0 , rotationSpeed * Time.deltaTime);
    }
}
