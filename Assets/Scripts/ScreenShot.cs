using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Threading;

public class ScreenShot : MonoBehaviour {

	private static ScreenShot _instance;

	public static ScreenShot Instance
	{
		get { return _instance; }
	}
		
	private void Awake ()
	{
		if (_instance == null) 
		{
			_instance = this;
		}
	}

	[HideInInspector]
	public Texture2D screenTexture;
	public Image shareImage;
	[HideInInspector] public string destination;

	// Use this for initialization
	void Start () {
	}

	public void PlayScreenShot ()
	{
		destination = Application.persistentDataPath + "/screenshot.png";

		// Take the screenshot
		ScreenCapture.CaptureScreenshot(destination);

//		// wait for graphics to render
//		yield return new WaitForEndOfFrame();
//
//		// put buffer into texture
//		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
//
//		// create the texture
//		screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24,true);
//
//		for (int i = 0; i < 9; i++)
//		{
//			yield return null;
//		}
//
//		// apply
//		screenTexture.Apply();
//
//		for (int i = 0; i < 9; i++)
//		{
//			yield return null;
//		}
//
//		Sprite sprite = Sprite.Create (screenTexture, new Rect (0, 0, screenTexture.width, screenTexture.height), new Vector2 (0.5f, 0.5f));
//		shareImage.GetComponent<Image>().sprite = sprite;
	
	}
		

	public void LoadImage()
	{
		// Read the data from the file
		byte[] data = File.ReadAllBytes(destination);


		// Create the texture
		screenTexture = new Texture2D(Screen.width, Screen.height);

		// Load the image
		screenTexture.LoadImage(data);

		// Create a sprite
		Sprite screenshotSprite = Sprite.Create(screenTexture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.5f));

		// Set the sprite to the screenshotPreview
		shareImage.GetComponent<Image>().sprite = screenshotSprite;
	}
		

}
