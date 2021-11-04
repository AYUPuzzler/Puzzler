using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Level1 : MonoBehaviour
{
    public static int game_Level;
    public Text Level;

    // Start is called before the first frame update
    void Start()
    {
        Level = GameObject.Find("Level").GetComponent<Text>();
        //ManagerData.instanceData.gameLevel = game_Level;
        //Level.text = game_Level.ToString();

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
        //ManagerData.instanceData.gameLevel = game_Level;
    }

    public void onClickLeft()
    {
        game_Level--;
        //ManagerData.instanceData.gameLevel = game_Level;
    }
}
