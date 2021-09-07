using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class X004_AutoNextLevel : MonoBehaviour
{
    void Start()
    {
        Invoke("NextStage", 37f);
    }

    void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
