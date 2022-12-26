using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class exit_main_menu : MonoBehaviour,IPointerClickHandler
{
    // Start is called before the first frame update
    private Button exit;
    private void Start()
    {
        exit = GetComponent<Button>();
    }
    
    //  public Scene main_menu;
  

    public void OnPointerClick(PointerEventData eventData)
    {
       
          Application.Quit();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
