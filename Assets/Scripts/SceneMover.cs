using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    public void Start1()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void Quit()
    {
        Application.Quit();   
    }
    public void Send()
    {
        SceneManager.LoadScene("Start");
    }
    void Update()
    {
        if(Input.GetButtonDown("Shoot"))
        {
            SceneManager.LoadScene("Main Scene");
        }
    }
}
