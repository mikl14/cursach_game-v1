using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_hero : MonoBehaviour
{
    private AudioSource audios;
    public AudioClip hodba;
    private bool upal;
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        upal = FindObjectOfType<walking>().upal;
    }

    // Update is called once per frame
    void Update()
    {
        
            upal = FindObjectOfType<walking>().upal;
            if ((((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow))) || ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow))) || (FindObjectOfType<bl_Joystick>().StickRect.position.x >= 280) || (FindObjectOfType<bl_Joystick>().StickRect.position.x <= 95)) && !upal)
            {
                audios.clip = hodba;
                if (!audios.isPlaying)
                {
                    audios.Play();
                }
            }
            else
            {
                audios.Stop();
            }
        
       
    }
}
