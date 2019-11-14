using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class movementscripts : MonoBehaviour
{
    [SerializeField]
    Animator am;
    [SerializeField]
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            am.SetTrigger("jump")
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            am.SetTrigger("Down");
        }
            
        transform.position += new Vector3(
            Input.GetAxis("Horizontal"),0, 0)
            * Time.deltaTime * 10;
        am.SetFloat("Speed",Input.GetAxis("Horizontal"));
        //if (Input.GetAxis("Horizontal") < 0)
        //    sr.flipX = true;
        //else if (Input.GetAxis("Horizontal") > 0)
        //    sr.flipX = false;

    }
}
