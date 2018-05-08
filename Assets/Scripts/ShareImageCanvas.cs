﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ShareImageCanvas : MonoBehaviour {

	//function called from a button
	public void ButtonShare ()
	{
		ShareScreenshot (); 
	}

	public void ShareScreenshot()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);

		GameManager.instance.objAds.SetActive (false);
		GameManager.instance.countDownTime = -1f;

		string filePath = Path.Combine( Application.persistentDataPath, "shared img.png" );
		File.WriteAllBytes( filePath, ScreenShot.Instance.screenTexture.EncodeToPNG() );

		new NativeShare().AddFile( filePath ).SetSubject( "Subject goes here" ).SetText( "Hello world!" ).Share();

		// Share on WhatsApp only, if installed (Android only)
		//if( NativeShare.TargetExists( "com.whatsapp" ) )
		//	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
	}
}
