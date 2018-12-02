using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPatrol : MonoBehaviour {

    

    public float enemySpeed;
    int changeD;
    
    private void Start()
    {
        if(Random.Range(0, 2) == 0)
        {
            ChangeDirection();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);      
        changeD = Random.Range(0, 1000);
        if (changeD == 0)
        {
            ChangeDirection();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collided");
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "wall")
        {
            //print("passed if");
            ChangeDirection();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transporter 1")
        {
            transform.position = new Vector3(-12, 16f, 0f);
        }
        else if (collision.gameObject.tag == "Transporter 2")
        {
            transform.position = new Vector3(27, 16f, 0f);
        }
    }

    public void ChangeDirection()
    {
        transform.Rotate(0f, 180f, 0f);
        //print("Changing direction");
    }
}

