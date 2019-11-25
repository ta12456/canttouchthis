using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        Destroy(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
