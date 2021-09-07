using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rigi2d;
    float moveSpd = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigi2d.velocity = new Vector2(-moveSpd, rigi2d.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigi2d.velocity = new Vector2(+moveSpd, rigi2d.velocity.y);
            }
        }
        if(Input.GetKey(KeyCode.W))
        {
            rigi2d.velocity = new Vector2(rigi2d.velocity.x, +moveSpd);
        }
    }
}
