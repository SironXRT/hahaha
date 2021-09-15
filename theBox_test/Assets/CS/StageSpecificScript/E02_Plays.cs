using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E02_Plays : MonoBehaviour
{
    Arduino arduino;
    int Knob;
    bool rewinding = false;
    AudioSource ads;
    public TimeRewinder tr;
    public RectTransform lever;
    bool lever_left = false;
    public Text txt;
    public RectTransform clock_P;
    // Start is called before the first frame update
    void Start()
    {
        arduino = GameObject.FindGameObjectWithTag("Cube").GetComponent<Arduino>();
        ads = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Knob = Mathf.Clamp(arduino.Button_Knob,0,999);

        if (!rewinding)
        {
            ads.pitch = Mathf.Lerp(0, 2, Knob / 1000f);
            Time.timeScale = Mathf.Lerp(0, 2, Knob / 1000f);
            clock_P.Rotate(Vector3.forward * Mathf.Lerp(0, 2, Knob / 1000f) * -1);
            txt.text = (Knob / 10f).ToString("f1") + " Hz";
        }

        if (arduino.Button_Press == 0 && !rewinding)
        {
            Time.timeScale = 1.5f;
            rewinding = true;
            tr.StartRewind();
            ads.pitch = -1.5f;
            txt.text = "Rewinding<<<";
        }

        if (arduino.Switch_State == 0 && !lever_left)
        {
            lever_left = true;
            lever.localScale = new Vector3(-lever.localScale.x, lever.localScale.y,1);
        }

        if (arduino.Switch_State == 1 && lever_left)
        {
            lever_left = false;
            lever.localScale = new Vector3(Mathf.Abs(lever.localScale.x), lever.localScale.y,1);
        }

        if (rewinding)
        {
            clock_P.Rotate(Vector3.forward * 1.5f);
        }

        if (arduino.Button_Press == 1 && rewinding)
        {
            rewinding = false;
            tr.StopRewind();
            ads.pitch = Mathf.Lerp(0, 2, Knob / 1000f);
            Time.timeScale = Mathf.Lerp(0, 2, Knob / 1000f);
            txt.text = (Knob / 10f).ToString() + " Hz";
        }


    }
}
