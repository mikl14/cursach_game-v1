using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            Destroy(coll.gameObject);
        }
        else
        {
            FindObjectOfType<Kill>().kill = true;
        }
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
