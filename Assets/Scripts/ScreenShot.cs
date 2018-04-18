using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

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
		
	[HideInInspector] public string destination;
	public Image shareImage;

	// Use this for initialization
	void Start () {
		
	}

	private IEnumerator ScreenShotActive ()
	{
		// wait for graphics to render
		yield return new WaitForEndOfFrame();

		destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		// create the texture
		Texture2D screenTexture = new Texture2D(Screen.width, Screen.height);//,TextureFormat.RGB24,true);
		// put buffer into texture
		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);

		// apply
		screenTexture.Apply();

		Sprite sprite = Sprite.Create (screenTexture, new Rect (0, 0, screenTexture.width, screenTexture.height), new Vector2 (0.5f, 0.5f));
		shareImage.GetComponent<Image>().sprite = sprite;

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		byte[] dataToSave = screenTexture.EncodeToPNG();

		new System.Threading.Thread(() =>
			{
				System.Threading.Thread.Sleep(100);
				File.WriteAllBytes(destination, dataToSave);
			}).Start();
	}

	public void PlayScreenShot ()
	{
		StartCoroutine (ScreenShotActive());
	}



}
