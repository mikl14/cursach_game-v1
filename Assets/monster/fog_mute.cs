using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fog_mute : MonoBehaviour
{
    float a ;
    // Start is called before the first frame update
    void Start()
    {
        a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<ghost_stoper>().check1)
        {
           
            // Debug.Log(a);
            if (a < 1)
            {
                a += 0.01f;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, a);

            }
           // a = gameObject.GetComponent<SpriteRenderer>().color.a;
        }
        if (FindObjectOfType<ghost_stoper>().check1)
        {
            if(a > 1)
            {
                a = 1;
            }
           // Debug.Log(a);
            if (a >= 0.2)
            {
                a-= 0.01f;
                gameObject.GetComponent<SpriteRenderer>().color =  new Color(255f, 255f, 255f,a);
               
            }
        }
    }
}
