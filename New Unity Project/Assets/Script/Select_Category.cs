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
            GameObject.Find("Canvas").transform.Find("LevelPanel").transform.Find("Jigsaw").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("LevelPanel").gameObject.SetActive(true);
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
            GameObject.Find("Canvas").transform.Find("LevelPanel").transform.Find("Slide").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("LevelPanel").gameObject.SetActive(true);

        }
        else
            SceneManager.LoadScene("Select_Photo");
    }


    public void ExitPanel()
    {
        if (ManagerData.instanceData.Category == 1)
        {
            GameObject.Find("Canvas").transform.Find("LevelPanel").transform.Find("Jigsaw").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("LevelPanel").gameObject.SetActive(false);
        }
        if (ManagerData.instanceData.Category == 2)
        {
            GameObject.Find("Canvas").transform.Find("LevelPanel").transform.Find("Slide").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("LevelPanel").gameObject.SetActive(false);

        }
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