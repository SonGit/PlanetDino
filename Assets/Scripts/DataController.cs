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
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		LoadPlayerProgress ();
	}

	public void SubmitNewPlayerScore(int newScore)
	{
		if (newScore > Player.highScore) {
			Player.highScore = newScore;
			SavePlayerProgress ();
		}
	}

	public float GetHighestPlayerScore ()
	{
		return Player.highScore;
	}

	public void LoadPlayerProgress ()
	{
		if (PlayerPrefs.HasKey ("HighestScore")) {
			Player.highScore = PlayerPrefs.GetInt ("HighestScore");
		}
	}

	private void SavePlayerProgress ()
	{
		PlayerPrefs.SetInt ("HighestScore", Player.highScore);
	}
}
