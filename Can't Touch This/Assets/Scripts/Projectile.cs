using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    const double CULL_OFFSET = 0.04;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Bound"))
        {
            Object.Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.SendMessage("onHit");
            //SceneManager.LoadScene("Death");
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 viewPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (viewPosition.x<-CULL_OFFSET*Screen.width|| viewPosition.x > ((1+CULL_OFFSET) * Screen.width)|| 
            viewPosition.y < -CULL_OFFSET * Screen.height|| viewPosition.y> (1+CULL_OFFSET)*Screen.height) Destroy(gameObject);
    }
}
