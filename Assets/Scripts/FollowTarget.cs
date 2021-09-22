using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform MainTarget;
    Transform currentTarget;
    [SerializeField] Vector3 offset;
    [Range(0,5)][SerializeField] float speedX;
    [Range(0, 5)] [SerializeField] float speedY;
    [SerializeField] public bool isFollowing;

    [Header("POSITION LIMITER")]
    [SerializeField] bool useBounding;
    [SerializeField] Transform xMIN,xMAX,yMIN,yMAX;
    [SerializeField] Vector3 bpos;
    [SerializeField] bool isOnBounding;
    [SerializeField] float radius;
    float x, y, z;
    float boundx, boundy;

    public enum postarget
    {
        maintarget,
        target
    }

    public postarget t;

    void FixedUpdate()
    {
        if (GameManager.gt == GameManager.GameStates.playing)
        {
            switch (t)
            {
                case postarget.maintarget:
                    currentTarget = MainTarget;
                    break;
                case postarget.target:
                    currentTarget = target;
                    break;
                default:
                    break;
            }
            //bouding position
            bpos = transform.position;

            if (useBounding)
            {
                bpos.Set(Mathf.Clamp(transform.position.x, xMIN.position.x, xMAX.position.x),
                        Mathf.Clamp(transform.position.y, yMIN.transform.position.y, yMAX.transform.position.y),
                        transform.position.z);
                transform.position = bpos;
                Follow();
            }
            else
            {
                Follow();
            }
        }
    }
    void Follow()
    {
        if (isFollowing)
        {
            x = Mathf.Lerp(transform.position.x + offset.x, currentTarget.position.x, speedX);
            y = Mathf.Lerp(transform.position.y + offset.y, currentTarget.position.y, speedY);
            //transform.position = Vector3.Lerp(transform.position + offset, t.position, speed);
            transform.position = new Vector3(x,y,offset.z);
        }
    }

}
