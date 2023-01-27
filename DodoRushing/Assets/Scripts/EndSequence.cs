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
        noOfFruitToEat = CollectibleManager.Instance.collectList.Count; 
        animator.SetTrigger("End");
        dayLight.SwitchToDayLight();
        //body.gameObject.SetActive(true);
        dayLight.
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        yield return new WaitForSeconds(spawnInterval);
        lastFruitSpawned = Instantiate(fruit, fruitSpawnPoint.position, Quaternion.identity);
        lastFruitSpawned.transform.DOMove(playerMouth.position, spawnInterval/2).OnComplete(() => body.GoBigger());
        noOfFruitToEat--;
        if (noOfFruitToEat > 0)
              StartCoroutine(SpawnFruit());
    }
    
    
    
}
