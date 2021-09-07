using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_UseKeyboard : MonoBehaviour
{
    RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rt.Rotate(new Vector3(0, 0, 1)); 
        }
        if (Input.GetKey(KeyCode.D))
        {
            rt.Rotate(new Vector3(0, 0, -1));
        }
    }
}
