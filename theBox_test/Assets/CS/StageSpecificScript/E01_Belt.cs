using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E01_Belt : MonoBehaviour
{
    public float speed;
    Arduino arduino;
    // Start is called before the first frame update
    void Start()
    {
        arduino = GameObject.FindGameObjectWithTag("Cube").GetComponent<Arduino>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (arduino.Switch_State == 1)
            {
                Debug.Log("Go Right.");
                col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
            }
            else
            {
                Debug.Log("Go Left.");
                col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
            }
        }
    }
}
