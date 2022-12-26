using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dead_screen : MonoBehaviour
{
    float secundomer;
    public bool go;
    // private SpriteRenderer spr;
    private Canvas s;
    public SpriteRenderer dead_scr;
  
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<Canvas>();

        s.planeDistance = -100;

        // spr = GetComponent<SpriteRenderer>();
        go = false;
    }


    // Update is called once per frame
    void Update()
    {
       
        if (go)
        {
            if ((FindObjectOfType<Kill>().kill == true) || (FindObjectOfType<nightstalker>().player_status == false))
            {
                dead_scr.sortingOrder = 10;
            }
           s.planeDistance = 100;
        }
        if (secundomer < 0.5f) secundomer += Time.deltaTime;

        if (secundomer > 0.5f && Input.GetKeyDown(KeyCode.Escape))
        {
            if(s.planeDistance == 100)
            {
                s.planeDistance = -100;
            }
            else
            {
                s.planeDistance = 100;
            }
            secundomer = 0;
        }
    }
}
