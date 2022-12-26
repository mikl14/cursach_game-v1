using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuel_indicator : MonoBehaviour
{
    private Animator anim;
   // float fuel1 = FindObjectOfType<lamp>().fuel;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (FindObjectOfType<lamp>().fuel > 270) // поменять если измениться размер бака 
        {
            anim.SetInteger("fuel", 100);
        }
        else
        {

            if (FindObjectOfType<lamp>().fuel > 240)
            {
                anim.SetInteger("fuel", 90);
            }
            else
            {
                if (FindObjectOfType<lamp>().fuel > 210)
                {
                    anim.SetInteger("fuel", 80);
                }
                else
                {
                    if (FindObjectOfType<lamp>().fuel > 180)
                    {
                        anim.SetInteger("fuel", 70);
                    }
                    else
                    {
                        if (FindObjectOfType<lamp>().fuel > 150)
                        {
                            anim.SetInteger("fuel", 60);
                        }
                        else
                        {
                            if (FindObjectOfType<lamp>().fuel > 120)
                            {
                                anim.SetInteger("fuel", 50);
                            }
                            else
                            {
                                if (FindObjectOfType<lamp>().fuel > 90)
                                {
                                    anim.SetInteger("fuel", 40);
                                }
                                else
                                {
                                    if (FindObjectOfType<lamp>().fuel > 60)
                                    {
                                        anim.SetInteger("fuel", 30);
                                    }
                                    else
                                    {
                                        if (FindObjectOfType<lamp>().fuel > 30)
                                        {
                                            anim.SetInteger("fuel", 20);
                                        }
                                        else
                                        {
                                            if (FindObjectOfType<lamp>().fuel > 0)
                                            {
                                                anim.SetInteger("fuel", 10);
                                            }
                                            else
                                            {
                                                if (FindObjectOfType<lamp>().fuel <= 0)
                                                {
                                                    anim.SetInteger("fuel", 0);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
