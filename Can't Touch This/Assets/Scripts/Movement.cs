using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpHeight;
    public float horizSpd;
    public float maxHorizSpd;
    public float numJumps;

    // Start is called before the first frame update
    void Start()
    {
        jumpHeight = 25;
        horizSpd = 1;
        maxHorizSpd = 5;

        numJumps = 3;

        // angular / vertical
        GetComponent<Rigidbody2D>().drag = 5;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Death"))
        {

        }
        else if (col.gameObject.CompareTag("Platform"))
        {
            //Vector2 direction = new Vector2(gameObject.transform);
            //print("First normal of the point that collide: " + col.contacts[0].normal);
            if (col.contacts[0].normal.y > 0) { 
                // reset jumps
                numJumps = 3;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
        }
        else if (col.gameObject.CompareTag("Bound"))
        {
            // reset jumps
            numJumps = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
        }
    }

    void adjustHorizSpeed(float xvel)
    {
        float hspd = 0;
        hspd = GetComponent<Rigidbody2D>().velocity.x - horizSpd;
        if (hspd > maxHorizSpd)
        {
            hspd = maxHorizSpd;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //bool jump = false;
        //detectGround()
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (numJumps >= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                //numJumps--;
            }
            
            //jump = true;
        }




        // Adjust horizontal speed - acceleration but have a maximum value
        float hspd = 0;
        if (Input.GetKey(KeyCode.A))
        {
            adjustHorizSpeed(GetComponent<Rigidbody2D>().velocity.x - horizSpd);
        }

        if (Input.GetKey(KeyCode.D))
        {
            adjustHorizSpeed(GetComponent<Rigidbody2D>().velocity.x + horizSpd);
        }




        // Upward movement = decrease gravity, downward movement = increase gravity
        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 5;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
        
    }
}
