using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class H017_ButtonMAP : MonoBehaviour
{
    public Arduino arduino;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        arduino = GameObject.FindGameObjectWithTag("Cube").GetComponent<Arduino>();
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino.Button_Press == 0)
        {
            img.enabled = true;
        }
        else
        {
            img.enabled = false;
        }
    }
}
