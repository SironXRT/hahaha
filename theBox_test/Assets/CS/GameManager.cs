using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public void CallNextStage(float transTime)
    {
        Invoke("NextStage", transTime);
    }

    public void CallRestartStage(float transTime)
    {
        Invoke("RestartStage", transTime);
    }

    void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void RestartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
