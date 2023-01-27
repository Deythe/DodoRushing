using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float radius = 1;
    [SerializeField] LayerMask playerMask;
    public enum Collectype { gold, fruit}
    public Collectype type;
    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, radius, playerMask))
            PickUp();
    }
    void PickUp()
    {
        Debug.Log("Pickup");
        CollectibleManager.Instance?.PickUpCollectible(this);
        if (type == Collectype.fruit)
            SoundManager.instance.PlaySoundOnce("PickUp");
        gameObject.SetActive(false);
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

