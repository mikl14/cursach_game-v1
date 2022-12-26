using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nightstalker : MonoBehaviour
{
    public GameObject Player;
 
    public bool death,halfdeath,oldhalfdeath;
    public bool player_status;
    private Transform target;
    private AudioSource dead_sound;
    public AudioClip safety_clip,dead_clip;
    private float secundomer;
    bool tick;
    // Start is called before the first frame update
    void Start()
    {
        tick = false;
        secundomer = 0;
        dead_sound = GetComponent<AudioSource>();
        dead_sound.volume = 0f;
        death = false;
        halfdeath = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player_status = true;
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            tick = true;
            player_status = false;
            //dead_sound.Stop();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(halfdeath && player_status)
        {
            if (!dead_sound.isPlaying)
            {

                dead_sound.PlayOneShot(dead_clip); 
            }
            else
            {
                if (dead_sound.volume < 1)
                {
                    dead_sound.volume += 0.0005f;
                }
            }  
        }
        else if(oldhalfdeath && !halfdeath)
        {
            if (dead_sound.isPlaying)
            {
                dead_sound.Stop();
               // dead_sound.clip = safety_clip;
                dead_sound.PlayOneShot(safety_clip);
            }
        }
        if(death == false)
        {
            gameObject.transform.position = Player.transform.position + new Vector3(-9, 0.9f, 0);
        }
        if(death)
        {
            
            FindObjectsOfType<safelight>()[0].status = false;
            FindObjectsOfType<safelight>()[1].status = false;
            FindObjectsOfType<safelight>()[2].status = false;
            transform.position = transform.position + new Vector3(0.12f, 0, 0);
           
        }


        oldhalfdeath = halfdeath;
    }
    private void Update()
    {
        if (secundomer < 1&&tick) secundomer += Time.deltaTime;
        if(secundomer > 1) FindObjectOfType<dead_screen>().go = true;
    }
}
