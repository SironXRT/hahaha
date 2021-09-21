using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class N_E01_Crane : MonoBehaviour
{
    Arduino arduino;

    public GameObject TitleScreenObj;
    bool TitleScreen = true;

    public GameObject Boat;
    public Vector2 Boat_MinMax;

    public LineRenderer lr;
    public Transform[] lr_points;
    public float lr_Z;

    public Vector2 Hook_MinMax;
    public RectTransform Hook;
    BoxCollider2D Hook_Col;
    public float Hook_Speed;

    public float hook_clamp, hook_y;
    int score;
    public Text Score_txt;
    // Start is called before the first frame update
    void Start()
    {
        arduino = GameObject.FindGameObjectWithTag("Cube").GetComponent<Arduino>();
        Hook_Col = Hook.gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TitleScreen)
        {
            //Knob & boat;
            int Knob = arduino.Button_Knob / 10;
            Boat.GetComponent<RectTransform>().transform.localPosition = new Vector3(Mathf.Lerp(Boat_MinMax.x, Boat_MinMax.y, Knob / 100f), Boat.GetComponent<RectTransform>().transform.localPosition.y, Boat.GetComponent<RectTransform>().transform.localPosition.z);

            //linerenderer
            for (int i = 0; i < lr_points.Length; i++)
            {
                lr.SetPosition(i, lr_points[i].position);//new Vector3(lr_points[i].position.x, lr_points[i].position.y, lr_Z));
            }

            //Fishing
            if (arduino.Switch_State == 1)
            {
                Hook_Col.enabled = false;
                Hook.localPosition -= new Vector3(0, Hook_Speed * Time.deltaTime, 0);
                Hook.localPosition = new Vector3(0, Mathf.Clamp(Hook.localPosition.y, Hook_MinMax.y, Hook_MinMax.x), 0);
            }
            else
            {
                Hook_Col.enabled = true;
                Hook.localPosition += new Vector3(0, Hook_Speed * Time.deltaTime, 0);
                Hook.localPosition = new Vector3(0, Mathf.Clamp(Hook.localPosition.y, Hook_MinMax.y, Hook_MinMax.x), 0);
            }
            
            //Score
            if (Hook.localPosition.y == -115)
            {
                if (Hook.gameObject.GetComponent<N_E01_Hook>().Score > 0)
                {
                    score += Hook.gameObject.GetComponent<N_E01_Hook>().Score;
                    Hook.gameObject.GetComponent<N_E01_Hook>().ClearScore();
                    Score_txt.text = score.ToString("D6");
                }
            }
            //Target Score >> NextStage

            return;
        }

        if (arduino.Button_Press == 0)
        {
            TitleScreen = false;
            TitleScreenObj.SetActive(false);
            lr.enabled = true;
        }
    }
}
