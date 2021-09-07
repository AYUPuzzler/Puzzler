using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Category : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Select_Photo");
    }
    public void OnClickExit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}