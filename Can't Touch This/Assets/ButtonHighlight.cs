using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonHighlight : MonoBehaviour
{
    Image imgScript;
    // Start is called before the first frame update
    void Start()
    {
        imgScript = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onHoverBegin()
    {
        //imgScript.color.a = 100;
    }

    void onHoverEnd()
    {
        //imgScript.color.a = 0;
    }

}
