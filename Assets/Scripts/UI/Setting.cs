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
		
	}

	public void MusicOn()
	{
		MusicBtns [0].SetActive (false);
		MusicBtns [1].SetActive (true);
	}

	public void MusicOff()
	{
		MusicBtns [0].SetActive (true);
		MusicBtns [1].SetActive (false);
	}

	public void SoundOn()
	{
		SoundBtns [0].SetActive (false);
		SoundBtns [1].SetActive (true);
	}

	public void SoundOff()
	{
		SoundBtns [0].SetActive (true);
		SoundBtns [1].SetActive (false);
	}

	public void Show()
	{
		gameObject.SetActive (true);
	}

	public void Hide()
	{
		gameObject.SetActive (false);
	}
}
