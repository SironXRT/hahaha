using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Debug_FollowMajor : MonoBehaviour
{
    public bool UI_Element = true;
    public RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (UI_Element) GetComponent<RectTransform>().rotation = rt.rotation;
        else transform.rotation = rt.rotation;
    }
}
