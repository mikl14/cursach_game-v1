using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class settings : MonoBehaviour, IPointerClickHandler
{

    // Start is called before the first frame update
    public Canvas main, setting;
    public Button bt1,bt2,bt3,bt4;
    private Button exit;
    private void Start()
    {
        exit = GetComponent<Button>();
    }

    //  public Scene main_menu;


    public void OnPointerClick(PointerEventData eventData)
    {
        if(main.sortingOrder == 1)
        {
            main.sortingOrder = -1;
            setting.sortingOrder = 1;
            bt1.transform.position = bt1.transform.position + new Vector3(100, 100, 0);
            bt2.transform.position = bt2.transform.position + new Vector3(100, 100, 0);
            bt3.transform.position = bt3.transform.position + new Vector3(100, 100, 0);
            bt4.transform.position = bt4.transform.position + new Vector3(100, 100, 0);
        }
        else
        {
            main.sortingOrder = 1;
            setting.sortingOrder = -1;
            bt1.transform.position = bt1.transform.position - new Vector3(100, 100, 0);
            bt2.transform.position = bt2.transform.position - new Vector3(100, 100, 0);
            bt3.transform.position = bt3.transform.position - new Vector3(100, 100, 0);
            bt4.transform.position = bt4.transform.position - new Vector3(100, 100, 0);
        }
       // Application.Quit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
