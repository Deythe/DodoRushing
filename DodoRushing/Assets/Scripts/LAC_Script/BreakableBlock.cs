using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BreakableBlock : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    Vector3 originPos;
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] Vector2 offset;
    [SerializeField] float triggerDuration = 2;
    [SerializeField] float triggerAmplitude = 0.05f;

    float triggerFreq = 0.1f;
    float triggerTimer = 0;
    bool isBroken = false;
    private void Start()
    {
        //boxCollider = GetComponent<BoxCollider2D>();
        originPos = transform.position;
    }
    private void Update()
    {
        if(!isBroken)
            CheckCollision();
        if (isBroken)
        {
            triggerTimer += Time.deltaTime;
            triggerDuration -= Time.deltaTime;

            if(triggerTimer > triggerFreq)
            {
                Vector2 randDir = new Vector2(Random.value - 0.5f, Random.value - 0.5f).normalized * triggerAmplitude;
                transform.position = originPos + (Vector3)randDir;
                boxCollider.offset = originPos - transform.position;
                triggerTimer = 0;
            }

            if (triggerDuration <= 0)
                Break();
        }
    }
    public void CheckCollision()
    {
        if(Physics2D.OverlapBox(originPos, boxCollider.size * transform.localScale + offset, 0, collisionLayer))
        {
            Debug.Log("Hit !");
            isBroken = true;
        }
            
    }
    public void Break()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxCollider.size * transform.localScale + offset);
    }

}
