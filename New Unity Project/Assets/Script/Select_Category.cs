using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Category : MonoBehaviour
{
    public static bool which = false;
    public static int Category = 0;
    public void Select_Jigsaw()
    {
        Category = 1;
        SceneManager.LoadScene("Select_Photo");
    }
    public void Select_Slide()
    {
        Category = 2;
        SceneManager.LoadScene("Select_Photo");
    }
    public void OnClickExit()
    {
        if(which == true)
        {
            which = false;
            SceneManager.LoadScene("MapScene");
        }
        else
        SceneManager.LoadScene("Select_Main");
    }
    void Esc()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}