using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class use : MonoBehaviour
{
    public Dropdown graf;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void click()
    {
        if (graf.value == 0)
        {
            Debug.Log("1920X1200");

            Screen.SetResolution(1920, 1200, true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (graf.value == 1)
        {
            Screen.SetResolution(1920, 1080, true);
            Debug.Log("1920X1080");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (graf.value == 2)
        {
            Screen.SetResolution(1600, 900, true);
            Debug.Log("1600X900");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (graf.value == 3)
        {
            Screen.SetResolution(1440, 900, true);
            Debug.Log("1440X900");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (graf.value == 4)
        {
            Screen.SetResolution(1280, 720, true);
            Debug.Log("1280X720");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
