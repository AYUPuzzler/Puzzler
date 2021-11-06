using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class ManagerData : MonoBehaviour
{
    public static ManagerData instanceData;
    public Sprite Image;        // 직소 퍼즐용
    public Texture2D texture2D; // 슬라이드 퍼즐용
    public int Category;
    public int gameCategory;
    public int gameLevel;
    public int JigsawLevel;

    private void Awake()
    {
        instanceData = this;

        DontDestroyOnLoad(gameObject);
        if(instanceData != null)
        {
            Destroy(this.gameObject);
            return;
        }
    }

}
