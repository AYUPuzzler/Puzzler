using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM Instance1;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance1 !=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance1 = this;
        DontDestroyOnLoad(transform.gameObject);
    }
}
