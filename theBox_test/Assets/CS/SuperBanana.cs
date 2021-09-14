using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SuperBanana : MonoBehaviour
{
    public void Active()
    {
        if (cs)
            change_Size = true;
        if (ct)
            change_Transform = true;
        if (cq)
            change_Quaternion = true;
        if (cc)
            change_Color = true;
    }

    public void Deactivate()
    {
        change_Size = false;
        change_Transform = false;
        change_Quaternion = false;
        change_Color = false;
    }

    public bool change_Size = true;
    public bool change_Transform = true;
    public bool change_Quaternion = true;
    public bool change_Color = true;
    bool cs;
    bool ct;
    bool cq;
    bool cc;

    public float SizeMax;
    public float SizeMin;
    public float TeRadius;
    public Vector2 OriginalPosition;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = this.GetComponent<RectTransform>().localPosition;
            cs = change_Size;
            ct = change_Transform;
            cq = change_Quaternion;
            cc = change_Color;
            change_Size = false;
            change_Transform = false;
            change_Quaternion = false;
            change_Color = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (change_Color)
            this.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        if (change_Size)
            this.GetComponent<RectTransform>().localScale = new Vector3(Random.Range(SizeMax, SizeMin),Random.Range(SizeMax, SizeMin), 1);
        if (change_Quaternion)
            this.GetComponent<RectTransform>().localRotation = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward);
        if (change_Transform)
            this.GetComponent<RectTransform>().localPosition = OriginalPosition + new Vector2(Random.Range(-TeRadius, TeRadius), Random.Range(-TeRadius, TeRadius));
    }
}