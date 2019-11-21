using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
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
            SceneManager.LoadScene("Death");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
