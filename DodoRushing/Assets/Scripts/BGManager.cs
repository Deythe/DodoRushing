using System;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    [SerializeField] private GameObject[] backgrounds;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceBetweenBgAndPlayerToCheckFor;
    [SerializeField] private float distanceToMoveBg;
    private float currentDistanceBetween;
    private void LateUpdate()
    {
        currentDistanceBetween = Vector3.Distance(backgrounds[1].transform.position, player.position);
        if (currentDistanceBetween < distanceBetweenBgAndPlayerToCheckFor)
        {
            MoveBg();
        }
    }
    
    private void MoveBg()
    {
        backgrounds[0].transform.position = backgrounds[2].transform.position + new Vector3(distanceToMoveBg,0,0);
        GameObject temp = backgrounds[0];
        backgrounds[0] = backgrounds[1];
        backgrounds[1] = backgrounds[2];
        backgrounds[2] = temp;
    }
}
