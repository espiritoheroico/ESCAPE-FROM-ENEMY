using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{

    #region Variables

    //Stats variables

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sprtr;

    [SerializeField] float speed = 0;
    [SerializeField] bool jump = false;
    [SerializeField] bool isonground = false;
    [SerializeField] float jumpforce = 0;

    [SerializeField] Animator anim;

    [SerializeField] float move_input_x;
    [SerializeField] float move_input_y;
    [SerializeField] float run =1;

    Vector2 jumpvector = new Vector2();

    RaycastHit2D hit;
    Ray ray;
    public Transform target;
    public float radius;
    public LayerMask layer;

    #endregion

    #region Functions


    void Start()
    {
    }

    void FixedUpdate()
    {
        //detect if the player is on ground
        isonground = Physics2D.OverlapCircle(target.position, radius, layer);
        //get inputs
        move_input_x = Input.GetAxis("Horizontal");
        move_input_y = Input.GetAxis("Vertical");
        //get button inputs


        //pass inputs through functions
        HorizontalMovement(move_input_x * run,speed *run);
        Jumping(jumpforce);

    }
    void HorizontalMovement(float x,float speed)
    {
        if (x > 0) sprtr.flipX = false;
        else if (x < 0) sprtr.flipX = true;

        anim.SetFloat("Running", Mathf.Abs(x));

        rb.velocity = new Vector2(x * speed , rb.velocity.y);
    }

    void Jumping(float jf)
    {
        if (Input.GetKeyDown(KeyCode.Space) && isonground == true)
        {
            rb.velocity = Vector2.up * jf;
            anim.SetTrigger("Jumping");
        }
    }

    void ActorDie()
    {
        anim.SetTrigger("Death");
    }

    #endregion
}
