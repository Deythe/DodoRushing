using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2 offsetCamera;

    private void Update()
    {
        transform.position = new Vector2(playerTransform.position.x, transform.position.y) + offsetCamera;
    }
}
