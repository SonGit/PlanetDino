using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {

	public GameObject[] MusicBtns;
	public GameObject[] SoundBtns;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUISetting ();
	}

	public void MusicOn()
	{
		Debug.Log ("off");
		DataController.Instance.SubmitMusicSetting ("f");

	}

	public void MusicOff()
	{
		Debug.Log ("on");
		DataController.Instance.SubmitMusicSetting ("t");
//		for (int i = 0; i < MusicThemeManager.instance.stems.Length; i++) {
//			MusicThemeManager.instance.stems [i].source.volume = 1;
//		}


	}

	public void SoundOn()
	{
		DataController.Instance.SubmitSoundSetting ("f");

		Debug.Log ("off");
	}

	public void SoundOff()
	{
		DataController.Instance.SubmitSoundSetting ("t");
		Debug.Log ("on");
	}

	public void Show()
	{
		gameObject.SetActive (true);
	}

	public void Hide()
	{
		gameObject.SetActive (false);
	}

	void UpdateUISetting()
	{
		UISound ();
		UIMusic ();
	}

	void UISound ()
	{
		if (DataController.Instance.GetSoundSetting () == "t") 
		{
			SoundBtns [0].SetActive (true);
			SoundBtns [1].SetActive (false);
		}

		if (DataController.Instance.GetSoundSetting () == "f")
		{
			SoundBtns [0].SetActive (false);
			SoundBtns [1].SetActive (true);
		}


	}


	void UIMusic ()
	{
		if (DataController.Instance.GetMusicSetting () == "t") 
		{
			MusicBtns [0].SetActive (true);
			MusicBtns [1].SetActive (false);
		}

		if (DataController.Instance.GetMusicSetting () == "f")
		{
			MusicBtns [0].SetActive (false);
			MusicBtns [1].SetActive (true);
		}


	}

}
