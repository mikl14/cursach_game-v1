using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    System.DateTime currentFirstStartupDate = System.DateTime.Today;
    public bool upal;
    public bool go;
    public float Speed = 0.02f;
    public float JumpForce = 1200;
    public float secundomer,secundomer_rand,stamina;
    public Animator animator;
    //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли
    public bool _isGrounded, freeze;
    private Rigidbody2D _rb;
    public Collider2D colli;
    private char lastkey;
    bool afk ;
    public Vector3 rotatess;
    private SpriteRenderer sr;
    public GameObject lamp;
    public GameObject Sfx;
    private AudioSource audio1;
    public AudioClip clip1;
    bool first = true;

    public void walk()
    {
        if (!freeze)
        {
            if (upal)
            {
                if (first)
                {
                    if (!audio1.isPlaying) audio1.PlayOneShot(clip1);
                    secundomer = 0;
                    first = false;
                }
                FindObjectOfType<lamp>().status = false;
                animator.SetBool("upal", true);

                if (secundomer > 2)
                {
                    animator.SetBool("upal", false);
                    upal = false;
                    first = true;
                    if (Random.Range(0, 100) <= 20)
                    {
                        Debug.Log("povezlo");
                        if (Random.Range(0, 100) <= 5)
                        {
                            FindObjectOfType<lamp>().povrezdenie_fuel = true;
                            FindObjectOfType<lamp>().povrezdenie_colba = true;
                            Debug.Log("ne povezlo");
                        }
                        else if (Random.Range(0, 100) <= 30)
                        {
                            FindObjectOfType<lamp>().povrezdenie_fuel = true;
                            Debug.Log("ne povezlo");
                        }
                        else if (Random.Range(0, 100) <= 20)
                        {
                            FindObjectOfType<lamp>().povrezdenie_colba = true;
                            Debug.Log("ne povezlo");
                        }
                    }
                }

            }

            animator.SetBool("jump", !_isGrounded);
            Quaternion myRotation = Quaternion.identity;
            afk = true;
            animator.SetBool("run", false);
            if (secundomer < 2) secundomer += Time.deltaTime;
            if (secundomer_rand < 6) secundomer_rand += Time.deltaTime;
            if (((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.Space)) || (Input.GetKey(KeyCode.UpArrow)) || (FindObjectOfType<bl_Joystick>().StickRect.position.y >= 210)) && !upal  )
            {
                if (secundomer >= 2)
                {
                    secundomer = 0;

                    if (_isGrounded && stamina > 10)
                    {
                        stamina -= 10;

                        if (lastkey == 'D')
                        {

                            _rb.AddForce(Vector3.right * (JumpForce - 200));
                        }
                        else
                        {
                            _rb.AddForce(Vector3.left * (JumpForce - 200));
                        }

                        _rb.AddForce(Vector3.up * JumpForce);


                    }
                }

                // JumpLogic();
            }
            if (_isGrounded)
            {

                if (((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)) || (FindObjectOfType<bl_Joystick>().StickRect.position.x < 191)) && !upal)
                {
                    transform.eulerAngles = rotatess;
                    if (!sr.flipX)
                    {
                        sr.flipX = true;
                        lamp.transform.position = lamp.transform.position - new Vector3(0.5f, 0, 0); // положение лампы
                    }
                    afk = false;

                    lastkey = 'A';
                    if ((((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow))) && (Input.GetKey(KeyCode.LeftShift))) || (FindObjectOfType<bl_Joystick>().StickRect.position.x <= 95))
                    {
                        if (stamina > 0)
                        {
                            stamina -= 1;
                        }
                        if (secundomer_rand > 6 && stamina <= 0)
                        {
                            // Debug.Log("adad");
                            secundomer_rand = 0;
                            if (Random.Range(0, 10) <= 2)
                            {
                                secundomer = 0;
                                upal = true;                                                               // падение на бегу 
                                goto padenie;
                            }
                        }
                        if (stamina > 0)
                        {
                            transform.position = transform.position + new Vector3(-Speed * 1.50f, 0, 0);
                        }
                        else
                        {
                            transform.position = transform.position + new Vector3(-Speed * 1.20f, 0, 0);
                        }
                    }
                    else
                    {
                        if (stamina < 400 && _isGrounded)
                        {
                            stamina += 1;
                        }
                        transform.position = transform.position + new Vector3(-Speed, 0, 0);
                    }
                    //MovementLogic();
                }

                if (((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)) || (FindObjectOfType<bl_Joystick>().StickRect.position.x > 191)) && !upal)
                {
                    transform.eulerAngles = rotatess;
                    if (sr.flipX)
                    {
                        sr.flipX = false;
                        lamp.transform.position = lamp.transform.position + new Vector3(0.5f, 0, 0); // положение лампы
                    }
                    afk = false;

                    lastkey = 'D';
                    // MovementLogic();
                    if (((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow))  && (Input.GetKey(KeyCode.LeftShift))) || (FindObjectOfType<bl_Joystick>().StickRect.position.x >= 280))
                    {
                        if (stamina > 0)
                        {
                            stamina -= 1;
                        }
                        if (secundomer_rand > 6 && stamina <= 0)
                        {
                            secundomer_rand = 0;
                            // Debug.Log("adad");
                            if (Random.Range(0, 10) <= 2)
                            {

                                secundomer = 0;
                                upal = true;                                                               // падение на бегу 
                                goto padenie;
                            }
                        }
                        if (stamina > 0)
                        {
                            transform.position = transform.position + new Vector3(Speed * 1.50f, 0, 0);
                        }
                        else
                        {
                            transform.position = transform.position + new Vector3(Speed * 1.20f, 0, 0);
                        }
                    }
                    else
                    {
                        if (stamina < 400 && _isGrounded)
                        {
                            stamina += 1;
                        }
                        transform.position = transform.position + new Vector3(Speed, 0, 0);
                    }
                }
                if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
                {
                    // afk = false;

                }

            }
            if (afk)
            {
                if (stamina < 400 && _isGrounded)
                {
                    stamina += 1;
                }
                animator.SetBool("run", false);

            }
            else
            {
                if (_isGrounded)
                {
                   
                    animator.SetBool("run", true);
                }
                else
                {
                    animator.SetBool("run", false);
                }
            }
        // animator.SetBool("run", false);
        padenie:;
        }
    }
    void Start()
    {
        go = false;
        audio1 = Sfx.GetComponent<AudioSource>();
        stamina = 400;
        freeze = false;
        upal = false;
        afk = true;
        animator = GetComponent<Animator>();
        lastkey = 'D';
        secundomer = 2;
        currentFirstStartupDate = System.DateTime.Today;
        _rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // обратите внимание что все действия с физикой 
    // необходимо обрабатывать в FixedUpdate, а не в Update
    void FixedUpdate()
    {
        if (go)
        {
            walk();
        }
    }
    void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.tag == ("Ground"))
        {
            _isGrounded = true;
        }
    }
    void OnCollisionStay2D(Collision2D colli)
    {
        if (colli.gameObject.tag == ("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D colli)
    {
        if (colli.gameObject.tag == ("Ground"))
        {
            _isGrounded = false;
        }
        
    }
    void animationswitch()
    {

    }
  
        // Update is called once per frame
        void Update()
        {
      
    }
}
