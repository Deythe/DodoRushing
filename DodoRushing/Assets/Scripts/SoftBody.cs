using DG.Tweening;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField] private Transform[] points;
    [SerializeField] private SpringJoint2D[] springJointCenter;
    [SerializeField] private SpringJoint2D[] springJointRight;
    [SerializeField] private SpringJoint2D[] springJointLeft;
    [SerializeField] private float fatterRatio = 0.5f;

    [SerializeField] private float colliderRadius;
    [SerializeField] private float splineOffset;
    
    [SerializeField] private CircleCollider2D centerCollider;
    [SerializeField] private Collider2D playerCollider;

    private Vector2 currentVertex;

    private Vector2 towardCenter;

    void Awake()
    {
        playerCollider.enabled = false;
        UpdateVertices();
    }

    private void Update()
    {
        UpdateVertices();
    }


    private void UpdateVertices()
    {
        for (int x = 0; x < points.Length - 1; x++)
        {
            currentVertex = points[x].localPosition;
            towardCenter = (Vector2.zero - currentVertex).normalized;
            try
            {
                spriteShapeController.spline.SetPosition(x, (currentVertex - towardCenter * colliderRadius));
            }
            catch
            {
                Debug.Log("Spline points are to close");
                spriteShapeController.spline.SetPosition(x,
                    (currentVertex - towardCenter * (colliderRadius + splineOffset)));
            }

            Vector2 lt = spriteShapeController.spline.GetLeftTangent(x);
            Vector2 newRt = Vector2.Perpendicular(towardCenter) * lt.magnitude;
            Vector2 newLt = Vector2.zero - (newRt);

            spriteShapeController.spline.SetRightTangent(x, newRt);
            spriteShapeController.spline.SetLeftTangent(x, newLt);
        }
    }
    
    public void GoBigger()
    {
        /*foreach (var spring in springJointCenter)
        {
            spring.autoConfigureDistance = false;
            spring.distance += fatterRatio;
            spring.dampingRatio = 0.5f;
        }

        foreach (var spring in springJointLeft)
        {
            spring.autoConfigureDistance = false;
            spring.distance += fatterRatio;
            spring.dampingRatio = 0.5f;
        }

        foreach (var spring in springJointRight)
        {
            spring.autoConfigureDistance = false;
            spring.distance += fatterRatio;
            spring.dampingRatio = 0.5f;
        }*/
        centerCollider.radius += fatterRatio;
        colliderRadius += colliderRadius/2;
        transform.DOScale(new Vector2(transform.localScale.x + fatterRatio,transform.localScale.y + fatterRatio), 0.5f);
        
    }
    
}