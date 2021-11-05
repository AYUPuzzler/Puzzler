using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Uni : MonoBehaviour
{
    // Start is called before the first frame update
    public void Select_Main()
    {
        SceneManager.LoadScene("Select_Main");
    }
    public void Anyang_Uni()
    {
        SceneManager.LoadScene("MapScene");
    }
}
