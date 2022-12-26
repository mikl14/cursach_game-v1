using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_stoper : MonoBehaviour
{
    public Light pointl;
    private AudioSource audio1;
    public bool check,check1;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        check = false;
        check1 = false;
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        check1 = false;
        if ((coll.gameObject.tag == "Player"))
        {
           
            if (FindObjectOfType<walking>().animator.GetFloat("speed_multiplier") < 1)
                FindObjectOfType<walking>().animator.SetFloat("speed_multiplier",1);

            if (audio1.isPlaying)
            {
                audio1.Stop();
            }
            check = false;
            FindObjectOfType<walking>().Speed = 0.02f;
            FindObjectOfType<game_controller>().cam = false;
        }
    }
 
        private void OnTriggerStay2D(Collider2D coll)
        {

        if ((coll.gameObject.tag == "Player"))
        {

            check = true;
            if (FindObjectOfType<lamp>().seek_status == true)
            {
                if ((!audio1.isPlaying)&&!check1&& (FindObjectOfType<Kill>().kill == false))
                {
                    check1 = true;
                    audio1.PlayOneShot(audio1.clip);
                }
                FindObjectOfType<game_controller>().cam = true;
                if (pointl.intensity < 25)
                {
                    pointl.intensity += 0.1f;
                }
                if (FindObjectOfType<walking>().Speed >= 0)
                {
                    FindObjectOfType<walking>().Speed -= 0.0001f;
                    if (FindObjectOfType<walking>().animator.GetFloat("speed_multiplier") > 0)
                        FindObjectOfType<walking>().animator.SetFloat("speed_multiplier", FindObjectOfType<walking>().animator.GetFloat("speed_multiplier") - 0.005f);
                }
                if (FindObjectOfType<walking>().Speed <= 0)
                {
                    FindObjectOfType<Kill>().kill = true;
                    FindObjectOfType<walking>().freeze = true;
                }

            }
            else
            {
                if (FindObjectOfType<walking>().Speed < 0.02)
                {
                    FindObjectOfType<walking>().Speed += 0.0002f;

                }
                if (FindObjectOfType<walking>().animator.GetFloat("speed_multiplier") < 1)
                    FindObjectOfType<walking>().animator.SetFloat("speed_multiplier", FindObjectOfType<walking>().animator.GetFloat("speed_multiplier") + 0.01f);
                if (pointl.intensity != 0) pointl.intensity -= 0.1f;

            }
        }
       

   }
        // Update is called once per frame
    void Update()
    {
        if(!check) if (pointl.intensity != 0) pointl.intensity -= 0.1f;
    }
}
