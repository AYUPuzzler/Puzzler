using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetImage : MonoBehaviour
{
    public Sprite Sp;
    public void selectedSpot()
    {
        //GameObject.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("SuriGwan");
        GameObject.Find("Image").GetComponent<Image>().sprite = Sp;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
