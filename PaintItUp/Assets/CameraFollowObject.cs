using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] Transform player;

    private void LateUpdate()
    {
        transform.position = new Vector3(0, player.position.y, player.position.z);
    }
}
