using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private GameObject Player;
    public float absX;
    public GameObject enemy;
    public int coll_enem ;
    // Start is called before the first frame update
    void Start()
    {
        absX = 4f;
        Player = GameObject.FindGameObjectWithTag("Player");
        //  coll_enem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Player.transform.position.x - transform.position.x > -8 )&&(Player.transform.position.x - transform.position.x < 2))
        {
            if (coll_enem > 0)
            {
                Instantiate(enemy, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
                coll_enem--;
            }
        }
      
    }
}
