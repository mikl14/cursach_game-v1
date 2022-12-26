using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public float speedX,speedY,time_to_drop;
     public Transform target;
    Rigidbody2D rb;
    private Collider2D coll;
    bool go;
    public bool search = true;
    float secundomer,secundomer_stay;
    public bool stun;
    public int count;
    private Animator animator;
    private AudioSource audio1;
    

    // Start is called before the first frame update
    void Start()
    {
       
        audio1 = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        stun = false;
        go = false;
        count = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    public void search_target()
    {
        speedX = (target.transform.position.x - transform.position.x) / time_to_drop;
        speedY = (target.transform.position.y - transform.position.y) / time_to_drop;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
     
        if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().seek_status == true) && (search)) //защита от переполнения 
        {
            count = 0;
        }
        if (!stun)
        {
            if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().seek_status == false))
            {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                search_target();
                go = false;
            }
        }
    }
   private void OnTriggerStay2D(Collider2D coll)
   {
        // Debug.Log("saa");
       
        if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().seek_status == true) && (search))
        {
            count = 0;
            if(audio1.isPlaying)
            {
                audio1.Stop();
            }
            animator.SetBool("is_target", false);
            FindObjectOfType<game_controller>().cam = false;
        }
        if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().seek_status == false) && (search) && (count < 3)) //защита от переполнения 
        {
            count++;
            if(count == 1)
            {
                //Debug.Log("1");
                animator.SetBool("is_target", true);
                FindObjectOfType<game_controller>().cam = true;
                if (!audio1.isPlaying)
                {
                    audio1.Play();
                }
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                search_target();
                stun = true;
            }
        }
      
        if (stun == false)
        {
            if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().seek_status == false) && (search))
            {
                transform.position = transform.position + new Vector3(speedX, 0, 0);
                transform.position = transform.position + new Vector3(0, speedY, 0);
                go = false;
            }
        }
       
   }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "Player") && (FindObjectOfType<lamp>().seek_status == false) && (search) ) //защита от переполнения 
        {
            count = 0;
            animator.SetBool("is_target", false);
            FindObjectOfType<game_controller>().cam = false;
            if (audio1.isPlaying)
            {
                audio1.Stop();
            }
        }
    }
    void FixedUpdate()
    {
        if (secundomer_stay > 1)
        {
            secundomer_stay = 0;
            stun = false;
        }
        if (secundomer > 7 && stun == false)
        {
            secundomer = 0;
            go = !go;

            speedX = Random.Range(-0.05f, 0.05f);
            speedY = Random.Range(-0.05f, 0.05f);
            //nextpoint();
        }
        if (go && stun == false)
        {
            transform.position = transform.position + new Vector3(speedX, 0, 0);
            transform.position = transform.position + new Vector3(0, speedY, 0);
        }

        if (search == false)
        {
            transform.position = transform.position + new Vector3(-0.04f, 0.08f, 0);
            if (audio1.isPlaying)
            {
                audio1.Stop();
            }
        }
    }
        // Update is called once per frame
        void Update()
        {
        if (secundomer < 7) secundomer += Time.deltaTime;
        if ((secundomer_stay < 1)&&(stun)) secundomer_stay += Time.deltaTime;
       
        }
}
