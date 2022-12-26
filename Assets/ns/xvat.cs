using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xvat : MonoBehaviour
{
    bool kill,destr;
    public float  time_to_drop;
    private Transform target;
    private float speedX, speedY;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        kill = false;
        destr = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().seek_status ==false)) //защита от переполнения 
        {
            kill = true;
        }
    }
    private void FixedUpdate()
    {
        if (kill)
        {

            transform.position = transform.position + new Vector3(0, 0.11f, 0);
        }
        if (gameObject.transform.position.y >= target.position.y)
        {
            destr = true;
            kill = false;
        }
        if (destr)
        {
           // GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
            if (count < 22)
            {
                // GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, -0.01f, 0);
                transform.position = transform.position + new Vector3(0, -0.08f, 0);
               
                count++;
            }
            //  transform.position = transform.position + new Vector3(0, -2, 0);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (destr)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;

        }
    }
}
