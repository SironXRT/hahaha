using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X005_ShowGoal : MonoBehaviour
{
    public MetaGuy mg;
    public GameObject Goalies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mg.CurrentMeta == 7)
        {
            Goalies.SetActive(true);
        }
    }
}
