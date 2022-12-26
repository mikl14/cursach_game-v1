using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chess : MonoBehaviour
{
    private Animator anim;
    private Collider2D coll;
    private AudioSource audio1;
    public GameObject bottle;
    public float secundomer;
    bool used,tick;
    public Vector3 start_pos = new Vector3();

   // Start is called before the first frame update
   void Start()
    {
        start_pos = GameObject.Find("use_button").transform.position;
       tick = false;
        used = false;
        audio1 = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        GameObject.Find("use_button").transform.position = new Vector3(5000, 5000, 0);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        FindObjectOfType<point>().clicked = false;
        if ((coll.gameObject.tag == "Player") && !used)
        {
            GameObject.Find("use_button").transform.position = start_pos;
        }
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (!used)
        {
            if (coll.gameObject.tag == "Player") 
            {
              
                if (FindObjectOfType<point>().clicked)
                {

                    if (!audio1.isPlaying)
                    {
                        audio1.Play();
                    }
                    anim.SetBool("open", true);

                    used = true;
                    tick = true;
                    FindObjectOfType<point>().clicked = false;
                }
            }
          
        }
       
      
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject.Find("use_button").transform.position = new Vector3(5000, 5000, 0);
            FindObjectOfType<point>().clicked = false;
        }
    }
        void spawn()
    {
        Instantiate(bottle);
    }
        // Update is called once per frame
        void Update()
    {
        if (secundomer < 0.1 && used && tick) secundomer += Time.deltaTime;
        if (secundomer > 0.1)
        {
            secundomer = 0;
            tick = false;
            spawn();
        }
    }
}
