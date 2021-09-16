using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GameScreen : MonoBehaviour
{
    /*
    [SerializeField]
    GameObject canvas;
    void Start()
    {
        Debug.Log(GameObject.Find("sp"));
        Select_Photo select_Photo = GameObject.Find("Select_Image").GetComponent<Select_Photo>();
        Texture2D texture = select_Photo.texture;


        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        canvas.GetComponent<Image>().sprite = sp;
    }
    */


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
