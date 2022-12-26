using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (Player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.05f, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<lamp>().povrezdenie_colba = true;
            FindObjectOfType<lamp>().povrezdenie_fuel = true;
            Destroy(gameObject);
            FindObjectOfType<game_controller>().end = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
