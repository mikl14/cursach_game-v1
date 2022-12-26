using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().status == true)) //защита от переполнения 
        {
            FindObjectOfType<lamp>().seek_status = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {

        if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().status == true) ) //защита от переполнения 
        {
            FindObjectOfType<lamp>().seek_status = false;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
