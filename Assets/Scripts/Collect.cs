using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public delegate void AddPointTo(string tag);
    public static event AddPointTo aPoint;
    public int getId;
    string itemTag;
    // Start is called before the first frame update
    private void OnEnable()
    {
        getId = this.gameObject.GetInstanceID();
        OnCollisionWith.OnCol += OnItemCollected;
    }

    void OnItemCollected(int id,string tag)
    {
        if (id == getId && tag == itemTag)
        {
            DisableMe();
            if (aPoint != null)
            {
                aPoint(itemTag);
            }
        }
    }
    private void DisableMe()
    {
        this.gameObject.SetActive(false);
        //send message to ADVENTURE and add a point
    }
}
