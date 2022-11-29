using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }
    public Dictionary<Collectible.Collectype, int> collectList = new Dictionary<Collectible.Collectype, int>();
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if(Instance != this)
            Destroy(this);
    }
    public void PickUpCollectible(Collectible c)
    {
        if (!collectList.ContainsKey(c.type))
            collectList.Add(c.type, 1);
        else
            collectList[c.type]++;

        Debug.Log("Add 1 "+c.type);
    }
}
