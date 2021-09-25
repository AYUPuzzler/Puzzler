using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class MoveSprite : MonoBehaviour
{
    public GameObject Selected;
    public void Awake()
    {
        Selected.GetComponent<SpriteRenderer>().sprite = ManagerData.instanceData.Image;
        
        //Vector3 SelectedSize = Selected.GetComponent<SpriteRenderer>().bounds.size;
        //Debug.Log(SelectedSize);

        //Vector3 leftDown = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        //Vector3 rightUp = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //float width = rightUp.x - leftDown.x;
        //float height = rightUp.y - leftDown.y;

        //float calWidth = width / 5;
        //float calHeight = height / 8;


        //Selected.transform.localScale = new Vector3(calWidth / SelectedSize.x, calHeight / SelectedSize.y, 1);

        //Transform Trans = Selected.GetComponent<Transform>();
        //Trans.position = new Vector2(-1.7771f, 1.0164f);
        //Trans.localScale = new Vector2(1.1767043f, 2.26645f);
    }
}
