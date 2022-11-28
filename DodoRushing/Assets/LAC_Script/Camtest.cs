using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camtest : MonoBehaviour
{
    public Camera cam;
    public Vector2 camPos;
    public Transform meteorOrigin;

    private void OnDrawGizmos()
    {
        Vector3 screenPos = cam.WorldToViewportPoint(meteorOrigin.position);
        screenPos.x = Mathf.Clamp(screenPos.x, 0, 1);
        screenPos.y = Mathf.Clamp(screenPos.y, 0, 1);
        Vector3 camMin = cam.ViewportToWorldPoint(screenPos);
        Gizmos.DrawCube(camMin, Vector3.one);
    }
}
