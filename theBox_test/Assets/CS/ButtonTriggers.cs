using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggers : MonoBehaviour
{
    AudioSource ads;
    public GameObject[] TargetObj;
    public int[] WhatTodo; // 0 = Hide
                             // 1 = Spawn
    bool triggered = false;

    public bool is_Switch = false;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (is_Switch)
            {
                ads.Play();
                for (int i = 0; i < TargetObj.Length; i++)
                {
                    switch (WhatTodo[i])
                    {
                        case 0:
                            TargetObj[i].SetActive(!triggered ? false : true);
                            break;

                        case 1:
                            TargetObj[i].SetActive(!triggered ? true : false);
                            break;
                    }
                }

                triggered = !triggered;
            }
            else if (!triggered)
            {
                ads.Play();
                for (int i = 0; i < TargetObj.Length; i++)
                {
                    switch (WhatTodo[i])
                    {
                        case 0:
                            TargetObj[i].SetActive(false);
                            break;

                        case 1:
                            TargetObj[i].SetActive(true);
                            break;
                    }
                }
                triggered = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ads = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
