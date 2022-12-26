using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public bool clicked;
    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
    }
    public void click()
    {
        clicked =  true;// ненавижу кнопки в юнити 
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
