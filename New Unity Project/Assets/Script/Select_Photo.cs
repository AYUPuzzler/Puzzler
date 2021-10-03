using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Select_Photo : MonoBehaviour
{
    public Texture2D texture;

    [SerializeField]
    GameObject canvas;
    public void OnClickSelect()
    {
        int maxSize = 512;
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {

            Debug.Log("Image path: " + path);
            if (path != null)
            {
                texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }



                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                quad.transform.forward = Camera.main.transform.forward;
                quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);

                Material material = quad.GetComponent<Renderer>().material;
                if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                    material.shader = Shader.Find("Legacy Shaders/Diffuse");

                material.mainTexture = texture;

                Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                canvas.GetComponent<Image>().sprite = sp;

                ManagerData.instanceData.texture2D = texture;
                ManagerData.instanceData.Image = sp;


            }
        });
        
        Debug.Log("Permission result: " + permission);

    }

    public void OnClickStartZigsaw()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void OnClickStarSlide()
    {
        SceneManager.LoadScene("SlidePuzzle");
    }


    public void OnClickExit()
    {
        SceneManager.LoadScene("Select_Category");
    }
    void Esc()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Select_Category");
        }
    }
}

