using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class H017_Teleport : MonoBehaviour
{
    //public int Teleport_ID;  //1 <-> 2, 3 <-> 4
    public GameObject t1, t2, t3, t4; //000#
    public GameObject p1, p2, p3, p4; //Player in 000#
    int Tp_ID_;
    IEnumerator TP_Stop()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.7f);
        Time.timeScale = 1;

        switch (Tp_ID_)
        {
            case 1:
                t1.SetActive(false);
                t2.SetActive(true);
                break;
            case 2:
                t2.SetActive(false);
                t3.SetActive(true);
                break;
            case 3:
                t2.SetActive(true);
                t3.SetActive(false);
                p2.GetComponent<RectTransform>().localPosition = new Vector3(-200, -200, 0);
                break;
            case 4:
                t2.SetActive(false);
                t3.SetActive(true);
                p3.GetComponent<RectTransform>().localPosition = new Vector3(-200, 200, 0);
                break;
            case 5:
                t3.SetActive(false);
                t4.SetActive(true);
                break;
            case 6:
                t4.SetActive(false);
                t3.SetActive(true);
                p3.GetComponent<RectTransform>().localPosition = new Vector3(200, -200, 0);
                break;
            case 7:
                t3.SetActive(false);
                t2.SetActive(true);
                p2.GetComponent<RectTransform>().localPosition = new Vector3(-100, 200, 0);
                break;
            case 8:
                t3.SetActive(true);
                t2.SetActive(false);
                p3.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                break;
            case 9:
                t2.SetActive(true);
                t3.SetActive(false);
                p2.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                break;
            case 10:
                t1.SetActive(true);
                t2.SetActive(false);
                p1.GetComponent<RectTransform>().localPosition = new Vector3(200, 0, 0);
                break;
            case 11:
                t2.SetActive(true);
                t1.SetActive(false);
                p2.GetComponent<RectTransform>().localPosition = new Vector3(200, 0, 0);
                break;
            case 12:
                t1.SetActive(true);
                t2.SetActive(false);
                p1.GetComponent<RectTransform>().localPosition = new Vector3(100, 200, 0);
                break;
        }
    }
    public void CallTP(int Tp_ID)
    {
        Tp_ID_ = Tp_ID;
        StartCoroutine(TP_Stop());
    }




}
