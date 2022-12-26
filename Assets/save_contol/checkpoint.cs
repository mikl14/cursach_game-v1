using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    bool zashel;
    private Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        zashel = false;
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (zashel == false)
            {
                zashel = true;
                Debug.Log(gameObject.name);
               FindObjectOfType<save_load>().Save(gameObject.name);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
