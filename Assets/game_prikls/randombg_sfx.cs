using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randombg_sfx : MonoBehaviour
{
    float secundomer;
    private AudioSource audio1;
    public AudioClip[] clip;
  
    // Start is called before the first frame update
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (secundomer < 25f ) secundomer += Time.deltaTime;
        if (secundomer > 25f)
        {
           
            secundomer = 0;
            if (!audio1.isPlaying) audio1.PlayOneShot(clip[Random.Range(0, clip.Length)]);


        }
    }
}
