using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorLanding : MonoBehaviour
{
    Camera cam;

    [Header("Meteor")]
    [SerializeField] GameObject meteorPrefab;
    Vector3 meteorSpawn;
    GameObject meteor;

    [Header("Landing")]
    [SerializeField] float landingDelay = 1;
    float launchTime = 0;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if(CheckInCamera() && !meteor)
            InitializeMeteor();
        if (meteor)
        {
            meteor.transform.position = Vector3.Lerp(meteorSpawn, transform.position, (Time.time - launchTime) / landingDelay);
            if((Time.time - launchTime) / landingDelay <1)
                meteor.transform.Rotate(0,0,360 * Time.deltaTime);
        }
            
    }
    public void InitializeMeteor()
    {
        Debug.Log("Launch meteor");
        meteorSpawn = transform.position - transform.up * 60;
        launchTime = Time.time;
        meteor = Instantiate(meteorPrefab, meteorSpawn, transform.rotation);
    }

    bool CheckInCamera()
    {
        Vector2 screenPos = cam.WorldToViewportPoint(transform.position);
        bool inRangeX = screenPos.x > 0 && screenPos.x < 1;
        bool inRangeY = screenPos.y > 0 && screenPos.y < 1;

        return inRangeX && inRangeY;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, -transform.up * 30);
    }
}
