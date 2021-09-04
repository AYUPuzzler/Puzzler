using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Photo : MonoBehaviour
{
    
    public void OnClickExit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}