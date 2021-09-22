using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    #region Variables
    Renderer rend;
    float ScrollOffset_X = 0;
    float ScrollOffset_Y = 0;

    [Header("Texture Scale")]
    [SerializeField]float TexturescaleX = 0;
    [SerializeField] float TexturescaleY = 0;

    [Header("Texture Scroll speed")]
    [Range(0,10)][SerializeField] float speed_scroll_x = 5;
    [Range(0, 10)] [SerializeField] float speed_scroll_y = 5;
    #endregion

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        if (GameManager.gt == GameManager.GameStates.playing)
        {
            //increase value scrooltime by time to animate offset
            SetTextureScale(TexturescaleX,
                        TexturescaleY);

            SetTextureOffset(speed_scroll_x,
                             speed_scroll_y);
        }
    }
    void SetTextureScale(float x =0,float y=0) 
    {
        //mainTextureScale SET THE TEXTURE SCALE, YOU CAN TRANSFORM THE TEXTURE USING IT
        rend.material.mainTextureScale = new Vector2(x, y);
    }
    void SetTextureOffset(float x = 0,float y = 0)
    {
        ScrollOffset_X += Time.deltaTime;
        ScrollOffset_Y += Time.deltaTime;
        //SetTextureOffset SETS THE TEXTURE OFFSET, TO CREATE PARALAX SCROLL EFECT
        //MAINTEX IS THE MAIN TEXTURE OF THE MATERIAL
        //"_MainTex" is the main diffuse texture. This can also be accessed via mainTexture property.
        rend.material.SetTextureOffset("_MainTex", new Vector2(ScrollOffset_X * x,
                                                                ScrollOffset_Y * y));
    }


}