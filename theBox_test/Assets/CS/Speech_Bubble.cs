using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Speech_Bubble : MonoBehaviour
{
    public Image Bubble;
    public Text txt;
    public string[] Strings;
    public float popupTime;
    public float AwaitTime;
    public bool floating = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(ShowCode());
            floating = true;
        }

        if (floating)
        {

        }
    }

    IEnumerator ShowCode()
    {
        while (Bubble.color.a < 1)
        {
            Bubble.color = new Color(Bubble.color.r, Bubble.color.g, Bubble.color.b, Bubble.color.a + Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        foreach (char letter in Strings[0].ToCharArray())
        {
            txt.text += letter;

            yield return new WaitForSeconds(AwaitTime);
        }
    }
}
