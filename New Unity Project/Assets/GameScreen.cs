using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GameScreen : MonoBehaviour
{

    public void OnClickExit()
    {
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
