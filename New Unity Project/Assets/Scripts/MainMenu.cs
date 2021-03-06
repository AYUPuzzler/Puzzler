using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void OnClickPanel()
    {
        GameObject.Find("Canvas").transform.Find("HowtoPlay").gameObject.SetActive(true);
    }

    public void OnClickPanelExit()
    {
        GameObject.Find("Canvas").transform.Find("HowtoPlay").gameObject.SetActive(false);
    }


    public void OnClickStart()
    {
        SceneManager.LoadScene("Select_Main");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Esc()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}

