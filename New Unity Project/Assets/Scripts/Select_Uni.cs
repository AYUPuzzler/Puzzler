using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Uni : MonoBehaviour
{
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Select_Main();
            }
        }
    }

    public void Select_Main()
    {
        SceneManager.LoadScene("Select_Main");
    }
    public void Anyang_Uni()
    {
        SceneManager.LoadScene("MapScene1");
    }
    public void Sungkuyl()
    {
        SceneManager.LoadScene("MapScene2");
    }
}
