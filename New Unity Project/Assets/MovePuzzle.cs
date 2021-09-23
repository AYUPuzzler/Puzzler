using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuzzle : MonoBehaviour
{
    public GameObject SelectedPiece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(origin: Camera.main.ScreenToWorldPoint(Input.mousePosition), direction: Vector2.zero);
            if (hit.transform.CompareTag("Selected"))
            {
                SelectedPiece = hit.transform.gameObject;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            SelectedPiece = null;
        }

        if(SelectedPiece != null)
        {
            Vector3 Mousepoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(Mousepoint.x, Mousepoint.y, 10.6f);
        }
    }
}
