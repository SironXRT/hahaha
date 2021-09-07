using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMoveTowards : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    public bool useDirection2 = false;
    public Vector3 direction2;
    public float halfCycleTime;
    float timer;
    bool gotoDirection2 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useDirection2)
        {
            timer += Time.deltaTime;
            
            if (gotoDirection2)
            {
                transform.localPosition = Vector3.Lerp(direction, direction2, timer / halfCycleTime);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(direction2, direction, timer / halfCycleTime);
            }

            if (timer >= halfCycleTime)
            {
                timer = 0;
                gotoDirection2 = !gotoDirection2;
            }
        }
        else
        {
            GetComponent<RectTransform>().localPosition += direction * speed * Time.deltaTime;
        }

    }
}
