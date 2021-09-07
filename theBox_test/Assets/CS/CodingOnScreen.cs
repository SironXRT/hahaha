using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CodingOnScreen : MonoBehaviour
{
    public Text Coder;
    public string[] CodeStrings;
    public float CodeAwaitsTime;

    public void CallShowCode()
    {
        StartCoroutine(ShowCode());
    }

    IEnumerator ShowCode()
    {
        foreach (string ss in CodeStrings)
        {
            if (ss == "<br>")
            {
                Coder.text = Coder.text + Environment.NewLine;
            }
            else
            {
                Coder.text = Coder.text + ss;
                yield return new WaitForSeconds(CodeAwaitsTime);
            }
        }
    }
}
