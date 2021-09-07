using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H017_Beaker : MonoBehaviour
{
    public int Tp_ID;
    H017_Teleport tp;
    // Start is called before the first frame update
    void Start()
    {
        tp = GameObject.FindGameObjectWithTag("GM").GetComponent<H017_Teleport>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            tp.CallTP(Tp_ID);
        }
    }
}
