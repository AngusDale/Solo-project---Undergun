using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpHeight;

    private float moveInput;

    private Rigidbody2D RigidB2D;

    private bool isLookingRight = false;
    public bool canMove = true;

    private bool OnFloor;
    public Transform floorCheck;
    public float checkRadius;
    public LayerMask whatsFloor;

    private int addedJumpNum;
    public int addedJumpNumInspector;

    int randSound;
    bool usedSound = false;

    public Animator animator;

    // Use this for initialization
    void Start()
    {
        canMove = true;
        animator = GetComponent<Animator>();
        addedJumpNum = addedJumpNumInspector;
        RigidB2D = GetComponent<Rigidbody2D>();
    }


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

    //Double jump was found in a Blackthorne Prod youtube tutorial.
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) { animator.SetBool("Jumping", true); }

            if (OnFloor == true)
            {
                animator.SetBool("Jumping", false);
                usedSound = false;
                addedJumpNum = addedJumpNumInspector;
            }

            if (OnFloor == true && Input.GetKeyDown(KeyCode.UpArrow))
            {

                SoundManager.PlayAudio("Jump 1");
            }
            if (OnFloor == false && usedSound == false && Input.GetKeyDown(KeyCode.UpArrow))
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

            if (Input.GetKeyDown(KeyCode.UpArrow) && addedJumpNum > 0)
            {
                RigidB2D.velocity = Vector2.up * jumpHeight;
                addedJumpNum--;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && addedJumpNum == 0 && OnFloor == true)
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
