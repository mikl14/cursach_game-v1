using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volume_dalnost : MonoBehaviour
{
    private AudioSource audio1;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

       if(gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x > 0) 
        {
            if (audio1.volume >= 0)
            {
                audio1.volume = 1 - ((gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x)/10);
            }
        }
       if(gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x < 0)
        {
            if (audio1.volume >= 0)
            {
                audio1.volume = 1 - (((gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x)/10)*-1);
            }
        }
    }
}
