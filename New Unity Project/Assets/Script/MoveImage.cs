using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MoveImage : MonoBehaviour
{
    public Image Selected;
    public void Awake()
    {
        Selected.sprite = ManagerData.instanceData.Image;
    }

}
