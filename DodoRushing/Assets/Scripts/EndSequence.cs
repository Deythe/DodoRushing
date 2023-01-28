using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndSequence : MonoBehaviour
{
    [SerializeField] private SoftBody body;
    [SerializeField] private Transform playerMouth;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject fruit;
    private GameObject lastFruitSpawned;
    [SerializeField] private Transform fruitSpawnPoint;
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private DayNightCycle dayLight;
    private int noOfFruitToEat = 100;

    private void Start()
    {
        noOfFruitToEat = CollectibleManager.instance.collectibleCount; 
        body.gameObject.SetActive(true);
        animator.SetTrigger("End");
        dayLight.SwitchToDayLight();
        //body.gameObject.SetActive(true);
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        yield return new WaitForSeconds(spawnInterval);
        lastFruitSpawned = Instantiate(fruit, body.transform.position + (Vector3.right*40), Quaternion.identity);
        lastFruitSpawned.transform.DOMove(playerMouth.position, spawnInterval/2).OnComplete(() => body.GoBigger());
        noOfFruitToEat--;
        if (noOfFruitToEat > 0)
              StartCoroutine(SpawnFruit());
    }
    
    
    
}
