using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckQuaternion : MonoBehaviour
{
    public Quaternion qua;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        qua = this.transform.rotation;
    }
}
