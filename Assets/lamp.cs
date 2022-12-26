using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : MonoBehaviour
{
    public GameObject Player;
    public bool status;
    public Collider2D coll;
    private Light light1;
    public bool tick,tick1,tick2,tick3;
    public float secundomer,secundomer_fuel,secundomer_F;
    public float fuel;
    public bool povrezdenie_fuel, povrezdenie_colba;
    bool switch_Status;
    private AudioSource audio1;
    public AudioClip on, off;
    public bool seek_status;

    // Start is called before the first frame update
    void Start()
    {
        
        seek_status = false;
        audio1 = GetComponent<AudioSource>();
        povrezdenie_fuel = false;
        povrezdenie_colba = false;
        fuel =120;
        status = true;
        light1 = GetComponent<Light>();
        light1.intensity = 10;
        tick1 = false;
        tick2 = true;
        tick3 = false;
        tick = true; // поменять если спавн в свете
        FindObjectOfType<moral>().change_tick(tick);
        FindObjectOfType<moral>().obnuli();
        secundomer = 0;
        secundomer_fuel = 0;
        secundomer_F = 0;
         switch_Status = false;
    }

    void FixedUpdate()
    {

    }
    public void Click()
    {
        if (fuel > 0)
        {
            if ((switch_Status == false) && (tick3 == false))
            {
                tick3 = true;
                // Debug.Log(switch_Status);
                if (status == false)
                {
                    if (!audio1.isPlaying)
                    {
                        audio1.clip = on;
                        audio1.Play();
                    }
                    tick1 = true;
                }
                switch_Status = true;

            }
        }
        else
        {
            //Debug.Log("fuel!!");
            if (status)
            {
                status = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (povrezdenie_fuel) fuel = 0;
        if ((povrezdenie_colba && (Input.GetKey(KeyCode.LeftShift)))&&((Input.GetKey(KeyCode.A))|| (Input.GetKey(KeyCode.D)))) status = false;
        if (secundomer < 3 && tick1) secundomer += Time.deltaTime;
        if (secundomer_F < 0.5 && tick3) secundomer_F += Time.deltaTime;
        if (secundomer_F > 0.5)
        {
            secundomer_F = 0;
            tick3 = false;
        }
        if (secundomer_fuel < 1 && tick2 && status) secundomer_fuel += Time.deltaTime;
        if(status)
        {
            fuel -= secundomer_fuel;
            secundomer_fuel = 0;
        }
        if (fuel > 0)
        {
            if ((Input.GetKey(KeyCode.F))&&(switch_Status == false)&&(tick3 == false))
            {
                    tick3 = true;
               // Debug.Log(switch_Status);
                if (status == false)
                {
                    if (!audio1.isPlaying)
                    {
                        audio1.clip = on;
                        audio1.Play();
                    }
                    tick1 = true;
                }
                switch_Status = true;

            }
        }
        else
        {
            //Debug.Log("fuel!!");
            if (status)
            {
                status = false;
            }
        }
        if (status)
        {
            if (light1.intensity != 10)
            {
                FindObjectOfType<nightstalker>().halfdeath = false;
                FindObjectOfType<moral>().lamp = true;
                light1.intensity = 10;
                seek_status = false;
            }

        }
        else
        {
            light1.intensity = 0;
            FindObjectOfType<moral>().lamp = false;
            seek_status = true;
        }

        if (status&&switch_Status)
        {
            if (!audio1.isPlaying)
            {
                audio1.clip = off;
                audio1.Play();
            }
            secundomer = 0;
            tick1 = false;
            status = !status;
            switch_Status = false;
        }
        else
        {
            
            if (secundomer > 3 && switch_Status)
            {
                tick1 = false;
                status = !status;
                fuel -= 10;
                secundomer = 0;
                switch_Status = false;
            }

        }
    }
}
