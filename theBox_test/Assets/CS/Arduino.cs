using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
public class Arduino : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM5", 115200);

    public Transform parentbox;

    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        Invoke("pp", 10);
    }

    void pp()
    {
        xGyroOrigin = qqa();
        //xGyroOriginInverse = Quaternion.Inverse(xGyroOrigin);
        
        parentbox.rotation = Quaternion.Inverse(new Quaternion(-y, -z, x, w));

        Debug.Log("Done.");
    }

    Quaternion qqa()
    {
        //new Quaternion(-y, -z, x, w) <- Original
        //return new Quaternion(x, w, -z, -y); All dimension wrong
        return new Quaternion(-y, -z, x, w);
    }

    public float w, x, y, z;
    Quaternion xGyroOrigin = Quaternion.identity;
    Quaternion xGyroOriginInverse = Quaternion.identity;
    public float xangle;
    public Quaternion qua;
    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                string data = sp.ReadLine();
                if (data != null)
                {
                    string[] values = data.Split('/');
                    if (values.Length == 5 && values[0] == "r")
                    {
                        w = float.Parse(values[1]);
                        x = float.Parse(values[2]);
                        y = float.Parse(values[3]);
                        z = float.Parse(values[4]);

                        //xangle = Quaternion.Angle(new Quaternion(-y, -z, x, w), xGyroOrigin);

                        this.transform.localRotation = qqa();// * xGyroOriginInverse;
                        qua = transform.rotation;
                        //this.transform.localRotation = xm;

                        sp.BaseStream.Flush();
                    }
                    else if (values.Length == 3)
                    {
                        x = float.Parse(values[0]);
                        y = float.Parse(values[1]);
                        z = float.Parse(values[2]);

                        this.transform.rotation = Quaternion.Euler(x, y, z);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
