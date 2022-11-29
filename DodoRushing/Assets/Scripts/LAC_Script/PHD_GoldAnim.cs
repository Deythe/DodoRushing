using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHD_GoldAnim : MonoBehaviour
{
    float scaleX;
    float speed = 1.2f;
    private void Start()
    {
        scaleX = transform.localScale.x;
    }
    private void Update()
    {
        
        float newScaleX = Mathf.Sin(Time.time * speed) * scaleX;
        //Debug.Log("new Scale" + newScaleX);
        transform.localScale = new Vector3 ( newScaleX, transform.localScale.y, transform.localScale.z);
    }
}
