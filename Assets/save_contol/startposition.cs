using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class startposition : MonoBehaviour
{
    // Start is called before the first frame update
    int k;
    float secundomer;
    bool tick;
   public GameObject load_screen;
  
    void Start()
    {
        load_screen.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
        //Debug.Log(gameObject.name);
        secundomer = 0;
        if (!File.Exists("Save.txt"))
        {
            File.Create("Save.txt");
            tick = true;
           
        }
        


        k = 1;
      
        // Debug.Log(File.ReadAllText("Save.txt"));
    }
    public static string stringBetween(string Source, string Start, string End)
    {
        string result = "";
        if (Source.Contains(Start) && Source.Contains(End))
        {
            int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
            int EndIndex = Source.IndexOf(End, StartIndex);
            result = Source.Substring(StartIndex, EndIndex - StartIndex);
            return result;
        }

        return result;
    }
    // Update is called once per frame
    void Update()
    {
        if (File.Exists("Save.txt"))
        {
            try
            {
                string s = File.ReadAllText("Save.txt");
                if (s.Length == 0)
                {
                    File.WriteAllText("Save.txt", "spawner1?120|");
                }
            }
            catch
            {

            }
        }
        if (secundomer < 0.5f &&tick) secundomer += Time.deltaTime;
        if(secundomer > 0.5f)
        {
            tick = false;
            secundomer = 0;
          
            File.WriteAllText("Save.txt", "spawner1?120|");
        }

        if (tick == false&&k>0)
        {
            k--;
           
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(GameObject.Find("s" + stringBetween(File.ReadAllText("Save.txt").ToString(), "s", "?")).transform.position.x+0.7f, -3.08f, -10);
            
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.Find("s" + stringBetween(File.ReadAllText("Save.txt").ToString(), "s", "?")).transform.position;
            FindObjectOfType<lamp>().fuel = float.Parse(stringBetween(File.ReadAllText("Save.txt").ToString(), "?", "|"));
           
        }
        if(k== 0)
        {
           
            var color = load_screen.GetComponent<SpriteRenderer>().color;
            color.a -= 1 * Time.deltaTime;
            color.a = Mathf.Clamp(color.a, 0, 1);
            load_screen.GetComponent<SpriteRenderer>().color = color;
            if (load_screen.GetComponent<SpriteRenderer>().color.a == 0)
            {
                k--;
            }
            
        }
    }
}
