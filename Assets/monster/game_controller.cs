using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_controller : MonoBehaviour
{
    public int coll_enemy;
    public bool spawner1_spawn, spawner2_spawn;
    public bool cam;
    public SpriteRenderer camera_drop;
    public Material m1;
    float counter;
    public bool end;
    public GameObject finalscreen;
    private SpriteRenderer spritefinal;
    // Start is called before the first frame update
    void Start()
    {
        spritefinal = finalscreen.GetComponent<SpriteRenderer>();
        cam = false;
        coll_enemy = 0;
        counter = 0;
        spawner1_spawn = true;
        spawner2_spawn = false;
        end = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
    void Update()
    {
        if(end)
        {
            FindObjectOfType<Kill>().dead_scr = finalscreen;
            FindObjectOfType<dead_screen>().dead_scr = spritefinal;
        }
       
        var color = camera_drop.color;
        if (cam)
        {
            color.a += 2 * Time.deltaTime;

        }
        else
        {
            color.a -= 1 * Time.deltaTime;

        }
        color.a = Mathf.Clamp(color.a, 0, 1);
        camera_drop.color = color;
    }
}
