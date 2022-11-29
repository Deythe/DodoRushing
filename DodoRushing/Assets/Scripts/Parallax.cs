using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector3 previousCameraPosition;
    private Transform camera;
    private Vector3 targetPosition;
    
    [SerializeField] private float parallaxAmount;

    private void Awake()
    {
        camera = Camera.main.transform;
        previousCameraPosition = camera.position;
    }
    
    private void LateUpdate()
    {
        Vector3 movement = CameraMovement;
        targetPosition = new Vector3(transform.position.x + movement.x * parallaxAmount, transform.position.y, transform.position.z);
        transform.position = targetPosition;

    }

    Vector3 CameraMovement
    {
        get
        {
            Vector3 movement = camera.position - previousCameraPosition;
            previousCameraPosition = camera.position;
            return movement;
        }
    }
    
}
