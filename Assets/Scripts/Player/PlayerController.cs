using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    /*This is my player controller which I have heavily modified for the use of my game. I initially learnt it from a blackthorn prod tutorial.
    This script allows the player to move left and right as well as tripple jump.*/


    public float speed;
    public float jumpHeight;

    private float moveInput;

    private Rigidbody2D RigidB2D;

    //I added the canMove bool in order to turn it off when the victory UI is displayed.
    private bool isLookingRight = false;
    public bool canMove = true;

    //the next 6 variables are in charge of the tripple jump.
    private bool OnFloor;
    public Transform floorCheck;
    public float checkRadius;
    public LayerMask whatsFloor;

    private int addedJumpNum;
    public int addedJumpNumInspector;

    int randSound;
    bool usedSound = false;

    public Animator animator;

    //The start function is just allowing us to reference the animator as well as setting canMove to true. It also sets the added jump number
    //equal to the one set in the inspector.
    void Start()
    {
        canMove = true;
        animator = GetComponent<Animator>();
        addedJumpNum = addedJumpNumInspector;
        RigidB2D = GetComponent<Rigidbody2D>();
    }

    /*This is my FixedUpdate function which deals with physics related stuff. OnFloor is constantly checking whether it is in contact with the
     floor. For the player's horizontal movement I am using GetAxisRaw instead of GetAxis because it makes the movement feel more responsive.
     The if statement is checking if the player is moving in a direction contrary to the way they are looking. If they are then the player 
     will change direction.*/
    void FixedUpdate()
    {
        if (canMove == true)
        {
            OnFloor = Physics2D.OverlapCircle(floorCheck.position, checkRadius, whatsFloor);

            moveInput = Input.GetAxisRaw("Horizontal");
            RigidB2D.velocity = new Vector2(moveInput * speed, RigidB2D.velocity.y);

            if (isLookingRight == true && moveInput < 0)
            {
                ChangeDirection();
            }
            else if (isLookingRight == false && moveInput > 0)
            {
                ChangeDirection();
            }
        }
    
    }

    /*Double jump was found in a Blackthorne Prod youtube tutorial. of canMove is true then it will procede onto many other if statements.
     The first will set the jumping animation to play when the up arrow is pressed. I'm also using a usedSound bool which checks whether
     the jumping sound has been made. If it has then  the second time the up arrow is pressed one of the second jump sounds will play.
     Again I achieved the random sound with a random number generator.
     
     When the up arrow is pressed and addedJumpNum is above 0 the player's vertical velocity will be set to the number set in the inspector for 
     JumpHeight. This is how the player is able to tripple jump.*/
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) { animator.SetBool("Jumping", true); }

            if (OnFloor == true)
            {
                animator.SetBool("Jumping", false);
                usedSound = false;
                addedJumpNum = addedJumpNumInspector;
            }

            if (OnFloor == true && Input.GetKeyDown(KeyCode.UpArrow) || OnFloor == true && Input.GetKeyDown(KeyCode.W))
            {

                SoundManager.PlayAudio("Jump 1");
            }
            if (OnFloor == false && usedSound == false && Input.GetKeyDown(KeyCode.UpArrow) || OnFloor == false && usedSound == false && Input.GetKeyDown(KeyCode.W))
            {
                randSound = Random.Range(0, 2);

                if (randSound == 0)
                {
                    SoundManager.PlayAudio("Jump 2");
                }
                else if (randSound == 1)
                {
                    SoundManager.PlayAudio("Jump 3");
                }
                usedSound = true;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && addedJumpNum > 0 || Input.GetKeyDown(KeyCode.W) && addedJumpNum > 0)
            {
                RigidB2D.velocity = Vector2.up * jumpHeight;
                addedJumpNum--;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && addedJumpNum == 0 && OnFloor == true || Input.GetKeyDown(KeyCode.W) && addedJumpNum == 0 && OnFloor == true)
            {
                RigidB2D.velocity = Vector2.up * jumpHeight;

            }
        }
    }

    void ChangeDirection()
    {
        isLookingRight = !isLookingRight;
        transform.Rotate(0f, 180f, 0f);
    }    
}
