using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ManagerLoad : MonoBehaviour
{
    public GameObject Selected;
    public Sprite Image;
    public Transform trImagePos;
    // Start is called before the first frame update
    void Start()
    {
        
        Image = ManagerData.instanceData.Image;
        //Selected = GameObject.Find("Selected");
        //Instantiate(Image, trImagePos);

        //Selected.GetComponent<Image>().sprite = Image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
