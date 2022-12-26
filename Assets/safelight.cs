using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safelight : MonoBehaviour
{
    public GameObject Player;
    private AudioSource audio1;
    public bool status;
    public Collider2D coll;
    private Light light1;
    public bool tick,tick_safety_light;
    public float secundomer;
    private bool perviy,perviy2;
    public GameObject clock_ui;
    public AudioClip clip_clock, clip_off;
    public float light_intensive;
    // Start is called before the first frame update
    void Start()
    {
        
        audio1 = GetComponent<AudioSource>();
        perviy = true;
        perviy2 = true;
        tick_safety_light = false;
        secundomer = 0;
        status = true;
        light1 = GetComponent<Light>();
      //  light1.intensity = 10;
        tick = true; // поменять если спавн в свете
        FindObjectOfType<moral>().change_tick(tick);
        FindObjectOfType<moral>().obnuli();
        //secundomer = 0;
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            FindObjectOfType<game_controller>().coll_enemy--;
            FindObjectOfType<spawner>().coll_enem--;
        }
        else
        {
            tick_safety_light = true;
          
            if (coll.gameObject.tag == "Player" && status)
            {
                tick = false;
                FindObjectOfType<moral>().change_tick(tick);
                FindObjectOfType<moral>().obnuli();
                //secundomer = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" )
        {
            tick = true;
            FindObjectOfType<moral>().change_tick(tick);

        }
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && status)
        {
            tick = false;
            FindObjectOfType<moral>().change_tick(tick);
            FindObjectOfType<moral>().obnuli();
            // secundomer = 0;
        }
        if(status == false)
        {
            light1.intensity = 0;
            tick = true;
            FindObjectOfType<moral>().change_tick(tick);
        }
       
    }
    public void statuschange(bool value)
    {
        status = value;
    }
    // Update is called once per frame
    void Update()
    {
        if (status) light1.intensity = light_intensive;
        else
        {
            light1.intensity = 0;
            if( perviy2)
            {
                audio1.clip = clip_off;
                perviy2 = false;
                audio1.Play();
                if (FindObjectOfType<nightstalker>().death != true)
                {
                    Destroy(GameObject.FindGameObjectsWithTag("clock")[0]);
                }
            }
           
        }
        if(secundomer < 60 && tick_safety_light) secundomer += Time.deltaTime;
        if(secundomer >= 50 && perviy)
        {
            perviy = false;
            
            Instantiate(clock_ui, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
        }
        if (secundomer >= 55) 
        {
            if (!audio1.isPlaying && status)
            {
                audio1.clip = clip_clock;
                audio1.Play();
               
            }
        }
        if (secundomer >= 60) status = false;

    }
}
