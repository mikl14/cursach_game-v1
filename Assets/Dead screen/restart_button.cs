using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class restart_button : MonoBehaviour, IPointerClickHandler
{
    private Button _Text;
   
    private void Start()
    {
        _Text = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //  _Text.text = _IsClicked ? "Hello there!" : "General Kenobi";
            FindObjectOfType<save_load>().Load();
       // _IsClicked = !_IsClicked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
