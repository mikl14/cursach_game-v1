using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf_trigger : MonoBehaviour
{
    public GameObject wolf;
    bool go ;
    private float secundomer;
    bool spawn;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn = true;
        go = false;
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&spawn)
        {
           
            Instantiate(wolf);
            wolf.transform.position =   new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x-20, -4, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position -= new Vector3(20, 0, 0);
            GameObject.FindGameObjectWithTag("nightstalker").GetComponent<SpriteRenderer>().sortingOrder = -10;
            GameObject.FindGameObjectsWithTag("ns1")[0].GetComponent<SpriteRenderer>().sortingOrder = -10;
            GameObject.FindGameObjectsWithTag("ns1")[1].GetComponent<SpriteRenderer>().sortingOrder = -10;
            spawn = false;
            go = true;
        }
    }
    void FixedUpdate()
    {
        if (secundomer > 4)
        {
            FindObjectOfType<walking>()._isGrounded = false;
            FindObjectOfType<game_controller>().cam = true;
            GameObject.FindGameObjectWithTag("MainCamera").transform.position += new Vector3(0.9f, 0, 0);
            if (GameObject.FindGameObjectWithTag("MainCamera").transform.position.x >= GameObject.FindGameObjectWithTag("Player").transform.position.x)
            {
                GameObject.FindGameObjectWithTag("nightstalker").GetComponent<SpriteRenderer>().sortingOrder = 3;
                GameObject.FindGameObjectWithTag("ns1").GetComponent<SpriteRenderer>().sortingOrder = 2;
                go = false;
                secundomer = 0;
                FindObjectOfType<walking>()._isGrounded = true;
            }
        }
    }
        // Update is called once per frame
   void Update()
    {
        if (secundomer < 4 && go) secundomer += Time.deltaTime;
    }
}
