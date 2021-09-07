using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    public bool isSuperpositioning = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Cube")
        {

        }
    }
}
