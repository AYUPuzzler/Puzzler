using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class ManagerData : MonoBehaviour
{
    public static ManagerData instanceData;
    public Sprite Image;        // ���� �����
    public Texture2D texture2D; // �����̵� �����
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
