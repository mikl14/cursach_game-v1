using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class save_load : MonoBehaviour
{
    // Start is called before the first frame update
    float secundomer,secundomer1;
    string check;
    bool tick,tick1;
    void Start()
    {
        /*  if (!File.Exists("Save.txt"))
          {
              File.Create("Save.txt");
              File.AppendAllText("Save.txt", "spawner1");
          }
         */
        tick = false;
    }
    public void clear()
    {
      
        File.Delete("Save.txt");
     
     
    }
    public void Save(string checkpoint)
    {
        check = checkpoint;
        clear();
        if (!File.Exists("Save.txt"))
        {
            File.Create("Save.txt");
         
        }
      
        tick = true;

    }
    public void Save1(string checkpoint)
    {
        try
        {
            Debug.Log(checkpoint + "?" + FindObjectOfType<lamp>().fuel.ToString() + "|");
            File.WriteAllText("Save.txt", checkpoint + "?"+ FindObjectOfType<lamp>().fuel.ToString() + "|");
        }
        catch
        {

        }
    }
        public void Load()
    {
        // File.ReadAllText("Save.txt");
        Debug.Log(File.ReadAllText("Save.txt"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
   
    }
    // Update is called once per frame
    void Update()
    {
        if (secundomer < 0.5f && tick) secundomer += Time.deltaTime;
      
        if (secundomer > 0.5f)
        {
            secundomer = 0;
            tick = false;
            Save1(check);
        }
     
            
        
    }
}
