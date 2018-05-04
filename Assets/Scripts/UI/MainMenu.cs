using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject Main;
	public GameObject Setting;
	public GameObject Score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToMain()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		Main.SetActive (true);
		Setting.SetActive (false);
//		if (Score != null) {
//			Score.SetActive (true);
//		}

	}

	public void GoToSetting()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		Main.SetActive (false);
		Setting.SetActive (true);
		if (Score != null) {
			Score.SetActive (false);
		}

	}

	public void LoadLevel ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
	}
}
