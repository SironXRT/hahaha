using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyBox : MonoBehaviour
{
    public Transform targetBox;
    public int TargetRotation;  // x = targetbox's x y z (0, 1, 2)
    //public int TransToRotation; // y = selftransfer x y z (0, 1, 2)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (TargetRotation)
        {
            case 0:
                this.transform.rotation = Quaternion.Euler(0, 0, targetBox.rotation.eulerAngles.x);
                break;

            case 1:
                this.transform.rotation = Quaternion.Euler(0, 0, targetBox.rotation.eulerAngles.y);
                break;

            case 2:
                this.transform.rotation = Quaternion.Euler(0, 0, targetBox.rotation.eulerAngles.z);
                break;
        }
    }
}
