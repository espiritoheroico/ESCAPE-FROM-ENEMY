using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWith : MonoBehaviour
{
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] Vector3 positionOffset;
    [SerializeField] Vector2 size;
    //
    public delegate void CollisionResult();
    public static event CollisionResult OnCollision;
    //
    RaycastHit2D hit;
    private void Awake()
    {

    }

    void Update()
    {
        Physics2D.OverlapBox(transform.position + positionOffset, size, 0,collisionLayer);
        if (hit)
        {
            CollisionEvent();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + positionOffset, size);
    }
    void CollisionEvent()
    {
        if (OnCollision != null)
        {
            OnCollision();
        }
    }


}
