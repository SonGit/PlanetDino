using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ShareImageCanvas : MonoBehaviour {

	private bool isProcessing = false;
	public string mensaje;
	public Image buttonShare;
	[HideInInspector] public string destination;

	//function called from a button
	public void ButtonShare ()
	{
		buttonShare.enabled = false;
		if(!isProcessing){
			ShareScreenshot ();
		}
	}
	public void ShareScreenshot()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);

		isProcessing = true;

		byte[] dataToSave = ScreenShot.Instance.screenTexture.EncodeToPNG();
		destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
		File.WriteAllBytes(destination,dataToSave);

		if(!Application.isEditor)
		{
			// block to open the file and share it ------------START
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

			intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), ""+ mensaje);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");

			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

			currentActivity.Call("startActivity", intentObject);
		}
		isProcessing = false;
		buttonShare.enabled = true;
	}
}
