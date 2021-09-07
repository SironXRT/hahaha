using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cube_Controll : MonoBehaviour
{
    //017 sound_
    public bool touching_x = false;
    public bool touching_y = false;
    public bool touching_z = false;
    bool sounded = false;

    public bool isSuperpositioning = false;
    public Cube_Controll TheOtherCube;
    //int SuperpositionTotal = 1;

    public AudioSource ads;

    public AudioClip[] AClips;

    public GameObject GM;
    public GameObject Allthing;

    public float NextStageTransTime; // Transition to next stage
    public bool goaled = false;
    bool dead = false;
    void OnCollisionEnter2D(Collision2D col)
    {
        /*if (col.gameObject.tag == "Silent_Block")
        {
            return;
        }*/
        if (col.gameObject.tag == "017x" && touching_x)
        {
            if (!touching_z) return;
        }
        if (col.gameObject.tag == "017y" && touching_y)
        {
            if (!touching_z) return;
        }
        if (col.gameObject.tag == "017x")
        {
            touching_x = true;
        }
        if (col.gameObject.tag == "017y")
        {
            touching_y = true;
        }
        if (!sounded)
        {
            ads.PlayOneShot(AClips[0]);
            ads.pitch = 1;
            sounded = true;
        }

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "017x")
        {
            touching_x = true;
        }
        if (col.gameObject.tag == "017y")
        {
            touching_y = true;
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "017x")
        {
            touching_x = false;
        }
        if (col.gameObject.tag == "017y")
        {
            touching_y = false;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "017z")
        {
            touching_z = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "017z")
        {
            touching_z = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "017z")
        {
            touching_z = true;
        }
        if (col.gameObject.tag == "Goal" && !goaled)
        {
            GetComponent<Rigidbody2D>().simulated = false;
            /*this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;*/
            goaled = true;
            
            /*if (isSuperpositioning)
            {
                if (TheOtherCube.goaled)
                {
                    GM.GetComponent<GameManager>().CallNextStage(NextStageTransTime);
                    GM.GetComponent<MetaGuy>().CallWinQuotes();
                    GM.GetComponent<CodingOnScreen>().CallShowCode();
                    ads.PlayOneShot(AClips[1]);
                    Invoke("CloseSection", 0.5f);
                }

            }
            else
            {*/
                GM.GetComponent<GameManager>().CallNextStage(NextStageTransTime);
                //GM.GetComponent<MetaGuy>().CallWinQuotes();
                //GM.GetComponent<CodingOnScreen>().CallShowCode();
                ads.PlayOneShot(AClips[1]);
                Invoke("CloseSection", 0.5f);
            /*}*/
        }

        if (col.gameObject.tag == "Death" && !dead)
        {
            GetComponent<Rigidbody2D>().simulated = false;
            /*this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;*/
            dead = true;
            ads.PlayOneShot(AClips[2]);
            GM.GetComponent<GameManager>().CallRestartStage(1f);
            Invoke("CloseSection", 0.5f);
        }
    }

    void CloseSection()
    {
        Allthing.SetActive(false);
    }

    void Start()
    {
        ads = this.GetComponent<AudioSource>();
        GM = GameObject.FindGameObjectWithTag("GM");
    }

    void LateUpdate()
    {
        sounded = false;
    }
}
