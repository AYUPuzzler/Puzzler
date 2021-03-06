using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GameScreen : MonoBehaviour
{
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                OnClickExit();
            }
        }
    }

    public void OnClickExit()
    {
        if (ManagerData.instanceData.gameCategory == 1)
            SceneManager.LoadScene("Select_Uni");
        else if(ManagerData.instanceData.gameCategory == 2)
            SceneManager.LoadScene("Select_Photo");
    }

    void Esc()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Select_Photo");
        }
    }

}
