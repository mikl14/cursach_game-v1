using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objects_take : MonoBehaviour
{
    public bool open,spawn;
    public GameObject list;
    public float secundomer;
    public Transform player;
    public GameObject show;
    public camera cam;
    // Start is called before the first frame update
    void Start()
    {
       // var color = new Color(1f, 51f, 3f, 0f);
        show.GetComponent<SpriteRenderer>().color = new Color(1f, 51f, 3f, 0f);
        spawn = false;
        secundomer = 0;
        open = false;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
      
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        show.GetComponent<SpriteRenderer>().color = new Color(1f, 51f, 3f, 0f);
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            {
            if (show.GetComponent<SpriteRenderer>().color.a != 255f)
            {
                //  var color = new Color(1f, 51f, 3f, 255f);
                show.GetComponent<SpriteRenderer>().color = new Color(1f, 51f, 3f, 255f);
            }
        }
        if ((coll.gameObject.tag == "Player") && (Input.GetKey(KeyCode.E)) )
            {
         
            
            if (secundomer >= 0.5)
            {
                if (open == false)
                {
                    secundomer = 0;
                    open = true;
                    if (spawn == false)
                    {
                        
                        Instantiate(list);
                        list.transform.position = cam.transform.position - new Vector3(0, 0, 1);
                        spawn = true;
                    }

                }
               else
                {
          
                    secundomer = 0;
                    if (spawn)
                    {
                        spawn = false;
                        try
                        {
                            Destroy(GameObject.FindGameObjectsWithTag("list")[1]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Destroy(GameObject.FindGameObjectsWithTag("list")[0]);
                        }
                        catch
                        {

                        }
                        open = false;
                    }
                }
            }

        }
          
    }
    // Update is called once per frame
    void Update()
    {
        if (secundomer < 0.5) secundomer += Time.deltaTime;
        if(open) FindObjectOfType<walking>()._isGrounded = false;
        try
        {
            list.transform.position = player.position + new Vector3(0, 1.2f, 1);
        }
        catch
        {

        }
    }
}
