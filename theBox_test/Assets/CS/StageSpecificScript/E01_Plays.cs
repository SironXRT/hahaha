using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E01_Plays : MonoBehaviour
{
    Arduino arduino;
    Rigidbody2D Player;
    bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        arduino = GameObject.FindGameObjectWithTag("Cube").GetComponent<Arduino>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino.Button_Press == 0 && !pressed)
        {
            pressed = true;
            Player.gravityScale = -Player.gravityScale;
        }
        
        if (arduino.Button_Press == 1 && pressed)
        {
            pressed = false;
        }
    }
}
