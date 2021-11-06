using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetImage : MonoBehaviour
{
    public Sprite Sp;

    public static Texture2D ConvertSpriteToTexture(Sprite sprite)
    {
        Debug.Log("te");
        try
        {
            if (sprite.rect.width != sprite.texture.width)
            {
                int x = Mathf.FloorToInt(sprite.textureRect.x);
                int y = Mathf.FloorToInt(sprite.textureRect.y);
                int width = Mathf.FloorToInt(sprite.textureRect.width);
                int height = Mathf.FloorToInt(sprite.textureRect.height);

                Texture2D newText = new Texture2D(width, height);
                Color[] newColors = sprite.texture.GetPixels(x, y, width, height);

                newText.SetPixels(newColors);
                newText.Apply();
                return newText;
            }
            else
                return sprite.texture;
        }
        catch
        {
            return sprite.texture;
        }
    } // sprite to texture

    public void selectedSpot()
    {
        //GameObject.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("SuriGwan");
        GameObject.Find("Image").GetComponent<Image>().sprite = Sp;
        ManagerData.instanceData.Image = Sp;
        ManagerData.instanceData.texture2D = ConvertSpriteToTexture(Sp);
        Debug.Log("success");
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
