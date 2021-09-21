using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform MainTarget;
    [SerializeField] Vector3 offset;
    [Range(0,5)][SerializeField] float speedX;
    [Range(0, 5)] [SerializeField] float speedY;
    [SerializeField] public bool isFollowing;
    float x, y, z;

    public enum postarget
    {
        maintarget,
        target
    }

    public postarget t;

    void Update()
    {
        switch (t)
        {
            case postarget.maintarget:
                Follow(MainTarget);
                break;
            case postarget.target:
                Follow(target);
                break;
            default:
                break;
        }
    }
    void Follow(Transform t)
    {
        if (isFollowing)
        {
            //transform.position = Vector3.Lerp(transform.position + offset, t.position, speed);
            x = Mathf.Lerp(transform.position.x + offset.x, t.position.x, speedX);
            y = Mathf.Lerp(transform.position.y + offset.y, t.position.y, speedY);
            transform.position = new Vector3(x,y,offset.z);
        }
    }
}
