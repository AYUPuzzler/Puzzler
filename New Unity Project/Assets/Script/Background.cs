using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Background : MonoBehaviour
{
    public int Speed = 60;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = new Vector3(x: Random.Range(-9f, 9f), y: Random.Range(3f, 30f));
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * Speed);
    }

}
