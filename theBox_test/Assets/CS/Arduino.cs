using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
public class Arduino : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM12", 115200);
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
    public int Button_Knob; //0~1023
    public int Button_Press;    //1=>off  0=>on
    public int Switch_State;    //1=>on  0=>off
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
                    if (values.Length == 9)
                    {
                        //if (values.Length == 5 && values[0] == "r")
                        //{
                        //0/1   /2/3/4/5     /6     /7      /8
                        // /1022/1/1/r/0.4600/0.4379/-0.5905/0.4980
                        // /旋鈕/按鈕(0是按下)/Switch(0是On)/r/W/X/Y/Z
                        Button_Knob = int.Parse(values[1]);
                        Button_Press = int.Parse(values[2]);
                        Switch_State = int.Parse(values[3]);
                        w = float.Parse(values[5]);
                        x = float.Parse(values[6]);
                        y = float.Parse(values[7]);
                        z = float.Parse(values[8]);

                        //xangle = Quaternion.Angle(new Quaternion(-y, -z, x, w), xGyroOrigin);

                        this.transform.localRotation = qqa();// * xGyroOriginInverse;
                        qua = transform.rotation;
                        //this.transform.localRotation = xm;

                        //sp.BaseStream.Flush();
                        sp.DiscardInBuffer();

                    }
                    //}
                    /*else if (values.Length == 3)
                    {
                        x = float.Parse(values[0]);
                        y = float.Parse(values[1]);
                        z = float.Parse(values[2]);

                        this.transform.rotation = Quaternion.Euler(x, y, z);
                    }*/
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
