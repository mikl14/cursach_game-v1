using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Dropdown))]
public class graf_setting : MonoBehaviour
{
  
    private Dropdown graf;
    // Start is called before the first frame update
    void Start()
    {
        graf = GetComponent<Dropdown>();
    }
    public void OnValueChanged()
    {
        /*  if(graf.value == 0)
          {
              Debug.Log("1920X1200");
              Screen.SetResolution(1920, 1200,true);
          }
          if (graf.value == 1)
          {
              Screen.SetResolution(1920, 1080, true);
              Debug.Log("1920X1080");
          }
          if (graf.value == 2)
          {
              Screen.SetResolution(1600, 900, true);
              Debug.Log("1600X900");
          }
          if (graf.value == 3)
          {
              Screen.SetResolution(1440, 900, true);
              Debug.Log("1440X900");
          }
          if (graf.value == 4)
          {
              Screen.SetResolution(1280, 720, true);
              Debug.Log("1280X720");
          }
          */
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
