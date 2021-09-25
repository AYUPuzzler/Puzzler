using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ImageCropperNamespace
{
	public class ImageCropperDemo : MonoBehaviour
	{
		public RawImage croppedImageHolder;
		public Text croppedImageSize;

		public Toggle ovalSelectionInput, autoZoomInput;
		public InputField minAspectRatioInput, maxAspectRatioInput;

		//
		public GameObject canvas;
		public Texture2D texture;
		//

		[SerializeField]
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

					ManagerData.instanceData.Image = sp;
				}
			});
		}

		public void Crop()
		{
			if (ImageCropper.Instance.IsOpen)
				return;

			StartCoroutine(SelectImageAndCrop());
		}

		private IEnumerator SelectImageAndCrop()
		{
			yield return new WaitForEndOfFrame();

			bool ovalSelection = ovalSelectionInput.isOn;
			bool autoZoom = autoZoomInput.isOn;

			float minAspectRatio, maxAspectRatio;
			if (!float.TryParse(minAspectRatioInput.text, out minAspectRatio))
				minAspectRatio = 0f;
			if (!float.TryParse(maxAspectRatioInput.text, out maxAspectRatio))
				maxAspectRatio = 0f;

			OnClickSelect();

			ImageCropper.Instance.Show(texture, (bool result, Texture originalImage, Texture2D croppedImage) =>
			{
				Destroy(croppedImageHolder.texture, 5f);

				if (result)
				{
					croppedImageHolder.enabled = true;
					croppedImageHolder.texture = croppedImage;

					Vector2 size = croppedImageHolder.rectTransform.sizeDelta;
					if (croppedImage.height <= croppedImage.width)
						size = new Vector2(400f, 400f * (croppedImage.height / (float)croppedImage.width));
					else
						size = new Vector2(400f * (croppedImage.width / (float)croppedImage.height), 400f);
					croppedImageHolder.rectTransform.sizeDelta = size;

					croppedImageSize.enabled = true;
					croppedImageSize.text = "Image size: " + croppedImage.width + ", " + croppedImage.height;
				}
				else
				{
					croppedImageHolder.enabled = false;
					croppedImageSize.enabled = false;
				}
				Destroy(texture);
			},
			settings: new ImageCropper.Settings()
			{
				ovalSelection = ovalSelection,
				autoZoomEnabled = autoZoom,
				imageBackground = Color.clear, // transparent background
				selectionMinAspectRatio = minAspectRatio,
				selectionMaxAspectRatio = maxAspectRatio

			},
			croppedImageResizePolicy: (ref int width, ref int height) =>
			{
				//width /= 2;
				//height /= 2;
			});
		}
		public void OnClickStart()
		{
			SceneManager.LoadScene("GameScreen");
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
}
