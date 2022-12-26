using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]

public class new_game : MonoBehaviour, IPointerClickHandler
{
   

    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        SceneManager.LoadScene(1);

    }
        // Update is called once per frame
    void Update()
    {
       

          
               
            
      
    }
}
