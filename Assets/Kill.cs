using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public Camera camera1;

    public bool kill,da,tick1,tick2;
    float speedX, speedY, time_to_drop = 8;
    public SpriteRenderer spriterend;
    public float secundomer, secundomer1;
    public GameObject music;
    private AudioSource audio1;
    public AudioClip clip1;
    int count;
    public GameObject dead_scr;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = music.GetComponent<AudioSource>();
        secundomer = 0;
        secundomer1 = 0;
        // spriterend = GetComponent<SpriteRenderer>();
        tick1 = false;
        kill = false;
        tick2 = false;
        
    }

    private void FixedUpdate()
    {
        speedX = (gameObject.transform.position.x - camera1.transform.position.x) / time_to_drop;
        speedY = (gameObject.transform.position.y - camera1.transform.position.y) / time_to_drop;
        if (kill)
        {
            FindObjectOfType<walking>().freeze = true;
            if (camera1.orthographicSize > 1f)
            {
               
                camera1.orthographicSize -= 0.05f;
                dead_scr.transform.localScale =new Vector3(0.19f,0.19f);
            }
            if ((camera1.transform.position.x - transform.position.x) > 0 )
            {
                
                camera1.transform.position = camera1.transform.position + new Vector3(speedX, 0, 0);
                
            }
            if ((camera1.transform.position.y - transform.position.y) > 0)
            {
               
                camera1.transform.position = camera1.transform.position + new Vector3(0, speedY, 0);
            }
           
                tick1 = true;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (secundomer < 1 && tick1) secundomer += Time.deltaTime;
        if ((secundomer >= 0.5) &&( secundomer <= 1))
        {
   
            FindObjectOfType<walking>().freeze = true;
            if (!audio1.isPlaying) audio1.PlayOneShot(clip1);
            tick2 = true;
        }
        if (secundomer1 < 4 && tick2) secundomer1 += Time.deltaTime;
        if (secundomer1 >= 4) FindObjectOfType<dead_screen>().go = true;
    }
}
