using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repair_objects : MonoBehaviour
{
    private Collider2D coll;
    public float secundomer;
    int fuel ;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<point>().clicked = false;
        fuel = 180;
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {

        FindObjectOfType<point>().clicked = false;
        if ((coll.gameObject.tag == "Player"))
        {
            GameObject.Find("use_button").transform.position = FindObjectOfType<chess>().start_pos;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (secundomer > 1)
        {
            if ((coll.gameObject.tag == "Player") && (FindObjectOfType<point>().clicked))
            {
                Destroy(gameObject);
                if (FindObjectOfType<lamp>().povrezdenie_colba == true)
                {
                    FindObjectOfType<lamp>().povrezdenie_colba = false;
                    fuel = fuel / 2;
                }
                if (FindObjectOfType<lamp>().povrezdenie_fuel == true)
                {
                    FindObjectOfType<lamp>().povrezdenie_fuel = false;
                    fuel = fuel / 2;
                }
                FindObjectOfType<lamp>().fuel = fuel;


            }
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        GameObject.Find("use_button").transform.position = new Vector3(5000, 5000, 0);
        FindObjectOfType<point>().clicked = false;
    }
        // Update is called once per frame
    void Update()
    {
        if (secundomer < 1) secundomer+= Time.deltaTime;
    }
}
