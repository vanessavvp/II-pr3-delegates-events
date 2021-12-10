using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Transform PlayerTransform;
    private Vector3 CameraOffset;
    public bool isLookAtPlayer = false;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    void Start()
    {
        PlayerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        CameraOffset = transform.position - PlayerTransform.position;
    }

    void LateUpdate()
    {
        Vector3 NewPosition = PlayerTransform.position + CameraOffset;
        transform.position = Vector3.Slerp(transform.position, NewPosition, SmoothFactor);
        if (isLookAtPlayer)
            transform.LookAt(PlayerTransform);
    }
}
