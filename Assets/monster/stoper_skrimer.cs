using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoper_skrimer : MonoBehaviour
{

    public GameObject ghost_stoper;
    bool count;
    private AudioSource audio1;
    public AudioClip clip1;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        count = false;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "Player")&&!count)
        {
            audio1.PlayOneShot(clip1);
            FindObjectOfType<lamp>().status = false;
           Instantiate(ghost_stoper, transform.position, Quaternion.identity);
            count = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
