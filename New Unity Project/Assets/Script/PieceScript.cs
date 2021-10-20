using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class PieceScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    public GameObject CompletePanel;
    void Completetest()
    {
        int count = 0;
        if (Select_Level.Level == 0)
        {
            for (int i = 0; i < 36; i++)
            {
                if (GameObject.Find("Piece (" + i + ")").GetComponent<PieceScript>().InRightPosition == true)
                    count++;
                if (count == 36)
                    CompletePanel.SetActive(true);
            }
        }
        if (Select_Level.Level == 1)
        {
            for (int i = 0; i < 64; i++)
            {
                if (GameObject.Find("Hard_Pieces (" + i + ")").GetComponent<PieceScript>().InRightPosition == true)
                    count++;
                if (count == 64)
                    CompletePanel.SetActive(true);
            }
        }
    }
    void Awake()
    {
        if (Select_Level.Level == 0)
        {
            Destroy(GameObject.Find("Hard"));
        }
        if (Select_Level.Level == 1)
        {
            Destroy(GameObject.Find("Normal"));
        }
        
    }
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(x : Random.Range(3.5f, 10f),y : Random.Range(4.5f, -5));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(a: transform.position, b: RightPosition) < 4f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    Completetest();
                }
            }
        }
    }
}
