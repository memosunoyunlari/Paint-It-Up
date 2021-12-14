using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] [Range(15, 60)] float rotationSpeed;

    [SerializeField] GameObject rotator;
    [SerializeField] GameObject stick;

    void Update()
    {
        rotator.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        stick.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
