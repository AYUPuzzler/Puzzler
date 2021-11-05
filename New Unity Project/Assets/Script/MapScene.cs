using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapScene : MonoBehaviour
{
    public void select_Category()
    {
        Select_Category.which = true;

        Debug.Log(ManagerData.instanceData.gameCategory);
        SceneManager.LoadScene("Select_Category");
    }
    public void Select_Uni()
    {
        SceneManager.LoadScene("Select_Uni");
    }
}

