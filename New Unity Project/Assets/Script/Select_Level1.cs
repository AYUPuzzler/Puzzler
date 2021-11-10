using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select_Level1 : MonoBehaviour
{
    public static int game_Level;
    public Text Level;

    // Start is called before the first frame update
    void Start()
    {
        Level = GameObject.Find("Level").GetComponent<Text>();
        game_Level = 3;

    }

    // Update is called once per frame
    void Update()
    {
        //level.text = "ManagerData.instanceData.gameLevel";
        Level.text = game_Level.ToString();
    }

     public void onClickRight() 
    {
        game_Level++;
    }

    public void onClickLeft()
    {
        if (game_Level > 3)
            game_Level--;
    }
    public void onClickPlay()
    {
        ManagerData.instanceData.slideLevel = game_Level;
        SceneManager.LoadScene("SlidePuzzle");
    }
}
