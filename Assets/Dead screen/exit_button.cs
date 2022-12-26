using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class exit_button : MonoBehaviour, IPointerClickHandler
{
   
    private Button exit;
 
    private void Start()
    {
        exit = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        SceneManager.LoadScene(0);
      
    }

   
    void Update()
    {

    }
   
 
}
