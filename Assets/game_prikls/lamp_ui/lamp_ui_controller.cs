using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp_ui_controller : MonoBehaviour
{
    private Animator anim;
 //   public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(cam.pixelWidth );
    //   transform.position = cam.transform.position - new Vector3((cam.pixelWidth/1500 + 1.69f), -1.369f, -10);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
            anim.SetBool("lamp_colba_broken", FindObjectOfType<lamp>().povrezdenie_colba);
        anim.SetBool("lamp_back_broken", FindObjectOfType<lamp>().povrezdenie_fuel);

    }
}
