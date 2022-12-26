using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
    private GameObject Player;
    public float absX ;
    public float camera_speed;
    bool baf,jump;
    // Start is called before the first frame update
    void Start()
    {
        baf = false;
        absX = 0.5f;
        jump = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        camera_speed = Player.GetComponent<walking>().Speed;
        //  Vector3 player = Player.GetComponent<Vector3>();
        // Rigidbody2D rb = Camera.GetComponent<Rigidbody2D>();
    }
  
    private void FixedUpdate()
    {
        if (Player.transform.position.x - transform.position.x > absX)
        {
            transform.position += new Vector3(camera_speed, 0, 0);
        }
        if (Player.transform.position.x - transform.position.x < -1* absX)
        {
            transform.position -= new Vector3(camera_speed, 0, 0);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && (FindObjectOfType<walking>()._isGrounded == false)&&(jump == false))
        {
            jump = true;
            if (camera_speed != Player.GetComponent<walking>().Speed * 2f)
            {
                camera_speed = Player.GetComponent<walking>().Speed * 2f;
            }
        }
        if((FindObjectOfType<walking>()._isGrounded == true)&&jump)
        {
            baf = false;
            jump = false;
            camera_speed = Player.GetComponent<walking>().Speed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (FindObjectOfType<walking>().stamina > 0)
            {
                if (camera_speed != Player.GetComponent<walking>().Speed * 1.75f)
                {
                    camera_speed = Player.GetComponent<walking>().Speed * 1.75f;
                }
            }
            else
            {
                if (camera_speed != Player.GetComponent<walking>().Speed * 1.25f)
                {
                    camera_speed = Player.GetComponent<walking>().Speed * 1.25f;
                }
            }
        }
        else
        {
            if (camera_speed != Player.GetComponent<walking>().Speed)
            {
                camera_speed = Player.GetComponent<walking>().Speed;
            }
        }
    }
       
   }
