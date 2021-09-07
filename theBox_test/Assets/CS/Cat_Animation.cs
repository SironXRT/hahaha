using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cat_Animation : MonoBehaviour
{
    Animator anime;
    Rigidbody2D rb;

    RectTransform rt;


    public float currentAngle, pureVelocity;

    void Start()
    {
        rt = GameObject.FindGameObjectWithTag("Rect").GetComponent<RectTransform>();    
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //testDv = DegreeToVector2(rt.localRotation.eulerAngles.z);
        //TestV2 = rb.velocity * DegreeToVector2(rt.localRotation.eulerAngles.z);

        currentAngle = Vector2ToDegree(rb.velocity.normalized) - rt.localRotation.eulerAngles.z + 360; //currentAngle
        pureVelocity = rb.velocity.magnitude;

        anime.SetFloat("CurrentAngle", currentAngle);
        anime.SetFloat("PureVelocity", pureVelocity);
    }

    public Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

    public Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public float Vector2ToDegree(Vector2 dir)
    {
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }
}
