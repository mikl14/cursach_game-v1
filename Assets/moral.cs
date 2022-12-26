using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moral : MonoBehaviour
{
    public bool tick;
    public float secundomer;
    public bool lamp;
    // Start is called before the first frame update
    public void change_tick(bool value)
    {
       tick = value;
       
    }
    public void obnuli()
    {
       
        secundomer = 0;
        FindObjectOfType<nightstalker>().halfdeath = false;
    }
        void Start()
    {
        lamp = true;
    }
    public void lampstatus(bool value)
    {
        lamp = value;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<Kill>().secundomer > 0.5)
        {
            tick = false;
        }
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0.000001f, 0);
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, -0.000001f, 0);///фиксит что колайдер не детектит стоячие объекты (это самое минимальное перемешение которое он задетектит только это число!!!!
        if ( lamp)
         {
            secundomer = 0;
         }
        if (secundomer < 10 && tick && !lamp) secundomer += Time.deltaTime;
        if (secundomer  > 7)
        {
            FindObjectOfType<nightstalker>().halfdeath = true;
        }
            if (secundomer > 10)
        {
            FindObjectOfType<lamp>().fuel = 0;
            FindObjectOfType<safelight>().statuschange(false);
            FindObjectOfType<nightstalker>().death = true;
        }

    }
}
