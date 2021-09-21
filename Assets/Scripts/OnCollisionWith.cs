using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWith : MonoBehaviour
{
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] Vector3 positionOffset;
    [SerializeField] Vector2 size;
    //
    public static OnCollisionWith coll;
    //

    RaycastHit2D hit;
    private void Awake()
    {
        coll = this;
    }

    void Update()
    {
        Physics2D.OverlapBox(transform.position + positionOffset, size, 0,collisionLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + positionOffset, size);
        GameManager.gt = GameManager.GameStates.menu;
    }
    public delegate void CollisionResult();
    public static event CollisionResult OnCollision;

    void CollisionEvent()
    {
        if (OnCollision != null)
        {
            OnCollision();
        }
    }


}
