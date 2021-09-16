using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MoveImage : MonoBehaviour
{
    public Texture2D texture;
    public void Move()
    {
        Select_Photo select_Photo = GameObject.Find("Select_Image").GetComponent<Select_Photo>();

        texture = select_Photo.texture;
        Debug.Log(texture);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        
    }

}
