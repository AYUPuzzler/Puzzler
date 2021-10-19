using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTrans: MonoBehaviour
{
    public GameObject StartPanel;
    public void SetPuzzlesPhoto (Image Photo)
    {
        if (Select_Level.Level == 0)
        {
            for (int i = 0; i < 36; i++)
            {
                GameObject.Find("Piece (" + i + ")").transform.Find("Selected").GetComponent<SpriteRenderer>().sprite = Photo.sprite;
            }
        }
        if (Select_Level.Level == 1)
        {
            for (int i = 0; i < 64; i++)
            {
                GameObject.Find("Hard_Pieces (" + i + ")").transform.Find("Hard_Selected").GetComponent<SpriteRenderer>().sprite = Photo.sprite;
            }
        }
        StartPanel.SetActive(false);
    }
}
