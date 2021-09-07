using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X007_ShowLogoDemo : MonoBehaviour
{
    public float startTimer;
    bool started = false;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("S", startTimer);
    }

    void S()
    {
        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            img.color = new Color(1, 1, 1, img.color.a + (Time.deltaTime * 0.5f));
        }
    }
}
