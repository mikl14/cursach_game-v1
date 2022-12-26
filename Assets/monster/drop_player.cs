using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_player : MonoBehaviour
{
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "GroundY"))
        {
            transform.parent.GetComponent<ghost>().speedX *= -1;
            
        }
        if ((coll.gameObject.tag == "Ground"))
        {
            transform.parent.GetComponent<ghost>().speedY *= -1;
        }
            if ((coll.gameObject.tag == "Player")&&(FindObjectOfType<lamp>().seek_status == false))
        {
            FindObjectOfType<walking>().upal = true;
            FindObjectOfType<ghost>().search = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
