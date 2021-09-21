using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{

    #region Variables

    //mechanic variables
    [Header("COMPONENTS")]
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sprtr;

    [Header("JUMP VERIFY")]
    [SerializeField] bool isonground = false;
    [SerializeField] float jumpforce = 0;

    [Header("MOVEMENT THE PLAYER")]
    [SerializeField] float move_input_x;
    [SerializeField] float move_pointer_x;
    //[SerializeField] float move_input_y; //for testing
    [SerializeField] float speed = 0;
    float startspeed;
    [SerializeField] float Maxspeed = 0;
    [SerializeField] float AnimationRun =1; //RUN INCREASE THE SPEED, THERE´S WALKING AND RUNNING, IT´S A BIT DIFERENT// speed will multiply and animation clip too

    [Header("RAYCAST TO FIND GROUND ")]
    [SerializeField] RaycastHit2D hit;
    [SerializeField] float dis;
    [SerializeField] bool raybool;

    [Header("COLLISION WITH OVERLAP CIRCLE")]//I USE OVERLAP + RAYCAST TO GET A PRECISE JUMP RESET MECHANIC
    [SerializeField] Transform target;
    [SerializeField] float radius;

    [Header("COLLISION LAYER MASK")]
    [SerializeField] LayerMask layer;


    public float delay = 0.5f;
    public float delta;
    #endregion

    #region Functions

    private void OnEnable()
    {
        startspeed = speed;
    }

    void FixedUpdate()
    {
        //detect if the player is on ground
        isonground = Physics2D.OverlapCircle(target.position, radius, layer);

        //get inputs
        move_input_x = Input.GetAxis("Horizontal") + move_pointer_x;

        //pass inputs through functions
        HorizontalMovement(move_input_x * AnimationRun, speed);
        Jumping(Input.GetKeyDown(KeyCode.Space));
        JumpVelocity(Time.deltaTime);

        //raycast
        hit = Physics2D.Raycast(target.transform.position, -Vector2.up,dis,layer);
        Debug.DrawRay(target.transform.position, -Vector2.up * dis);
        
        raybool = hit.collider ? true : false;
        if (!raybool) anim.SetTrigger("Falling");//IF IS IN THE AIR, FALL ANIMATION IS CALLED
    }

    void JumpVelocity(float dt) //ITS BREAK THE JUMP VELOCITY TO DON´T GLUE ON THE WALL
    {
        if (isonground)
        {
            speed = startspeed;
        }
        else speed -= dt * 2;
    }

    void HorizontalMovement(float x,float speed)
    {
        if (x > 0) sprtr.flipX = false;
        else if (x < 0) sprtr.flipX = true;

        if (isonground) { anim.SetBool("idle", true); anim.SetFloat("Running", Mathf.Abs(x)); }
        else {anim.SetBool("idle", false); }

        rb.velocity = new Vector2(x * speed , rb.velocity.y);
    }
    public void Jumping(bool key)
    {
        if (key && isonground == true && raybool)
        {
            anim.SetTrigger("Jumping");
            rb.velocity = new Vector2(move_input_x * jumpforce / 2, 1 * jumpforce);
        }
    }
    public void Running(bool key)
    {
        if (key)
        {
            AnimationRun = 2;
            speed = Maxspeed;
        }
        else {
            AnimationRun = 1;
            speed = startspeed;
        }
    }
    public void ActorDie()
    {
        anim.SetTrigger("Death");

    }
    void OnDrawGizmos()
    {
        //DRAW OVERLAP CIRCLE
        Gizmos.DrawSphere(target.transform.position, radius);
        Gizmos.color = Color.red;
    }
    public void PointerDir(float s)
    {
        move_pointer_x = s;
    }

    #endregion
}
