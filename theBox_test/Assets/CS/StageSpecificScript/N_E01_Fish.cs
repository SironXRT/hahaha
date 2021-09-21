using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_E01_Fish : MonoBehaviour
{
    public Vector2 Size_minmax;
    float Size;
    public Vector2 Speed_minmax;
    float speed;
    bool to_left;
    public int Score;
    public bool SpecialFish = false;
    // Start is called before the first frame update

    void OnEnable()
    {
        float yy = Random.Range(-58f, 132);
        GetComponent<RectTransform>().localPosition = to_left ? new Vector3(-350, yy, GetComponent<RectTransform>().localPosition.z) : new Vector3(350, yy, GetComponent<RectTransform>().localPosition.z);

        to_left = Random.Range(0, 2) == 0 ? false : true;

        Size = Random.Range(Size_minmax.x, Size_minmax.y);

        GetComponent<RectTransform>().localScale = Vector3.one * Random.Range(Size_minmax.x, Size_minmax.y);
        if (!SpecialFish) Score = Mathf.RoundToInt(1000 * Size);

        if (to_left)
        {
            GetComponent<RectTransform>().localScale = new Vector3(Mathf.Abs(GetComponent<RectTransform>().localScale.x), GetComponent<RectTransform>().localScale.y, 1);
        }
        else
        {
            GetComponent<RectTransform>().localScale = new Vector3(Mathf.Abs(GetComponent<RectTransform>().localScale.x) * -1f, GetComponent<RectTransform>().localScale.y, 1);
        }

        speed = Random.Range(Speed_minmax.x, Speed_minmax.y);
        GetComponent<Rigidbody2D>().velocity = to_left ? Vector3.right * speed : Vector3.right * -speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            GetComponent<RectTransform>().localPosition = to_left ? new Vector3(-350, GetComponent<RectTransform>().localPosition.y, GetComponent<RectTransform>().localPosition.z) : new Vector3(350, GetComponent<RectTransform>().localPosition.y, GetComponent<RectTransform>().localPosition.z);
        }
    }
}
