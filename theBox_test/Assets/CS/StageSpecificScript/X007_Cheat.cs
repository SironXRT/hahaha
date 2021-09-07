using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X007_Cheat : MonoBehaviour
{
    public Text porttext;
    public GameObject port1, port2;
    bool nowp1 = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (nowp1)
            {
                //port1.SetActive(false);
                //port2.SetActive(true);
                porttext.text = "PORT 2";
                nowp1 = false;
            }
            else
            {
                //port1.SetActive(true);
                //port2.SetActive(false);
                porttext.text = "PORT 1";
               nowp1 = true;
            }
        }
    }
}
