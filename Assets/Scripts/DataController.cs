using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

	private static DataController _instance;

	public static DataController Instance
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
	// Use this for initialization
	void Start () {
		LoadPlayerProgress ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SubmitNewPlayerScore(float newScore)
	{
		if (newScore < Planet.highScore) {
			Planet.highScore = newScore;
			SavePlayerProgress ();
		}
	}

	public float GetHighestPlayerScore ()
	{
		return Planet.highScore;
	}

	private void LoadPlayerProgress ()
	{
		if (PlayerPrefs.HasKey ("HighestScore")) {
			Planet.highScore = PlayerPrefs.GetFloat ("HighestScore");
		}
	}

	private void SavePlayerProgress ()
	{
		PlayerPrefs.SetFloat ("HighestScore", Planet.highScore);
	}
}
