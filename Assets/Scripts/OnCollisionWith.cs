using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWith : MonoBehaviour
{
    #region Variables
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] Vector3 positionOffset;
    [SerializeField] Vector2 size;
    [SerializeField] CharacterController cc;
    //
    public delegate void OnCollision(int id,string tag);
    public static event OnCollision OnCol;
    //
    Collider2D col;
    [SerializeField]int collidedobjID;
    [SerializeField] string collisionTag;
    #endregion
    private void Start()
    {
        cc = this.gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        col = Physics2D.OverlapBox(transform.position + positionOffset, size, 0,collisionLayer);
        if (col)
        {
            //Debug.Log("I FOUNDED");
            collidedobjID = col.gameObject.GetInstanceID();
            CollisionEvent(collidedobjID, tag);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + positionOffset, size);
    }
    public void CollisionEvent(int id,string tag)
    {
        if (OnCol != null)
        {
            OnCol(id, tag);
        }
    }


}
