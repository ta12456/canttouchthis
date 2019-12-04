using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float jumpHeight;
    public float horizSpd;
    public float maxHorizSpd;
    public float numJumps;
    public GameObject pauseScreen;
    public GameObject deathScreen;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        jumpHeight = 15;
        horizSpd = 1;
        maxHorizSpd = 6;

        numJumps = 3;

        // angular / vertical
        GetComponent<Rigidbody2D>().drag = 5;
        //scoreText = GetComponent<Text>();
    }

    void onHit()
    {
        
            
            int score = (int)Time.timeSinceLevelLoad;
            //If hits projectile or other death cause
            //"pause the game"
            Time.timeScale = 0;
            //Show death screen
            pauseScreen.SetActive(false);
            deathScreen.SetActive(true);
            
            //Show score
            scoreText.text = "Score: "+score;

            
            //Update High Score list if needed
            string s = PlayerPrefs.GetString("scores");
            int c = 0;
            int[] parsed = new int[10];
            while (s.Contains(">"))
            {
                //int i = s.IndexOf(">");
                s = s.Substring(s.IndexOf(">") + 1);
            if (s.IndexOf(">") < 0) parsed[c] = int.Parse(s.Substring(0));
            else parsed[c] = int.Parse(s.Substring(0, s.IndexOf(">")));
                c++;
               
            }

            for (int i = 0;i<10;i++)
            {
                if (score > parsed[i])
                {
                    for (int j = 9;j>i;j--)
                    {
                        parsed[j] = parsed[j - 1];
                    }
                    parsed[i] = score;
                    break;
                }
            }
            s = "";
            for (int i = 0; i < 10; i++)
            {
                s+=">"+parsed[i];
            }

            //Save new highscore list
            PlayerPrefs.SetString("scores", s);


        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collide "+col.gameObject.tag);
        
        if (col.gameObject.CompareTag("Platform"))
        {
            //Vector2 direction = new Vector2(gameObject.transform);
            //print("First normal of the point that collide: " + col.contacts[0].normal);
            if (col.contacts[0].normal.y > 0) { 
                // reset jumps
                numJumps = 3;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bound"))
        {
            SceneManager.LoadScene("Death");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }*/

    void adjustHorizSpeed(float xvel)
    {
        float hspd = xvel;//GetComponent<Rigidbody2D>().velocity.x - horizSpd;
        if (hspd > maxHorizSpd)
        {
            hspd = maxHorizSpd;
        }
        else if (hspd < -maxHorizSpd)
        {
            hspd = -maxHorizSpd;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(hspd, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //bool jump = false;
        //detectGround()
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (numJumps > 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                numJumps--;
            }
        }




        // Adjust horizontal speed - acceleration but have a maximum value
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
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 5;
        }
        
    }
}
