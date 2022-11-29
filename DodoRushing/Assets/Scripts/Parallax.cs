using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float length;
    float startPosition;

    public GameObject camera;

    public float tempDisplay;

    public float parallaxIntensity;

    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = camera.transform.position.x * (1 - parallaxIntensity);
        tempDisplay = temp;
        float distance = camera.transform.position.x * parallaxIntensity;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (temp > startPosition + length)
        { 
            startPosition += length;
        }
        else if (temp < startPosition - length)
        {
            startPosition -= length;
        }

    }
}
