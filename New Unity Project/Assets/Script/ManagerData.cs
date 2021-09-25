using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class ManagerData : MonoBehaviour
{
    public static ManagerData instanceData;
    public Sprite Image;
    private void Awake()
    {
        instanceData = this;

        DontDestroyOnLoad(gameObject);
    }

}
