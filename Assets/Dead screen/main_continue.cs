using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]
public class main_continue : MonoBehaviour,IPointerClickHandler
{
    // Start is called before the first frame update
    private Button _Text;
    bool loading;
    public GameObject load_screen;

    void Start()
    {
        loading = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        loading = true;
        //  _Text.text = _IsClicked ? "Hello there!" : "General Kenobi";
        
        // _IsClicked = !_IsClicked;
    }
    // Update is called once per frame
    void Update()
    {
        if (loading)
        {


            var color = load_screen.GetComponent<SpriteRenderer>().color;
            color.a += 1 * Time.deltaTime;
            color.a = Mathf.Clamp(color.a, 0, 1);
            load_screen.GetComponent<SpriteRenderer>().color = color;
            if (load_screen.GetComponent<SpriteRenderer>().color.a ==1)
            {
              
                SceneManager.LoadScene(1);
                loading = false;
            }
        }
    }
}
