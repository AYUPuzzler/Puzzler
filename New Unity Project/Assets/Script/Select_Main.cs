using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Main : MonoBehaviour
{
    // Start is called before the first frame update
    public void Main()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Select_Uni()
    {
        ManagerData.instanceData.gameCategory = 1;

        Debug.Log(ManagerData.instanceData.gameCategory);
        SceneManager.LoadScene("Select_Uni");
    }
    public void Select_Category()
    {
        ManagerData.instanceData.gameCategory = 2;
        SceneManager.LoadScene("Select_Category");
    }

}
