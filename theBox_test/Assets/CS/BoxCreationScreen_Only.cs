using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This Script is used in Box_Creation_Scene Only, for the purpose of auto adjusting & scene changing.

public class BoxCreationScreen_Only : MonoBehaviour
{
    public float AdjustTime = 11f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Call_Next", AdjustTime);
    }


    void Call_Next()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
