using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Category : MonoBehaviour
{
    public static bool which = false;
    public void Select_Jigsaw()
    {
        ManagerData.instanceData.Category = 1;
        //Debug.Log(ManagerData.instanceData.gameCategory);
        if (ManagerData.instanceData.gameCategory == 1) {
            //SceneManager.LoadScene("Select_Photo");
            SceneManager.LoadScene("GameScreen");
        }
        else
            SceneManager.LoadScene("Select_Photo");
    }
    public void Select_Slide()
    {
        ManagerData.instanceData.Category = 2;

        //Debug.Log(ManagerData.instanceData.gameCategory);
        if (ManagerData.instanceData.gameCategory == 1)
        {
            //SceneManager.LoadScene("Select_Photo");
            SceneManager.LoadScene("SlidePuzzle");
        }
        else
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