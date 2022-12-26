using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamina_ui : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<walking>().stamina < 100)
        {
            var color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 0.8f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            if (gameObject.GetComponent<SpriteRenderer>().color.a != 0)
            {
                var color = gameObject.GetComponent<SpriteRenderer>().color;
                color.a = 0;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
}
