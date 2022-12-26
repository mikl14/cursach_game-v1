using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Scrollbar))]
public class brightness : MonoBehaviour
{
    private Scrollbar brit;
    // Start is called before the first frame update
    void Start()
    {
        brit = GetComponent<Scrollbar>();
        brit.value = 0.5f;
    }
    public void OnValueChanged()
    {

    }
    // Update is called once per frame
    void Update()
    {
    }
}
