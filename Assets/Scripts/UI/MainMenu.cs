using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject Main;
	public GameObject Setting;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToMain()
	{
		Main.SetActive (true);
		Setting.SetActive (false);
	}

	public void GoToSetting()
	{
		Main.SetActive (false);
		Setting.SetActive (true);
	}

	public void LoadLevel ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
