using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject gameOverUI;
	public TextMeshProUGUI countDownText;
	public GameObject objGameOverText;
	public GameObject objAds;
	public GameObject[] containerBtns;
	public GameObject gamePlayUI;
	public GameObject objScore;
	public GameObject objHighScore;
	public List<Enemy> enemyList;

	[HideInInspector]
	public float countDownTime = 10;
	[HideInInspector]
	public bool isCountdown;

	void Start ()
	{
		enemyList = new List<Enemy> ();
	}

	void Awake ()
	{
		instance = this;
	}

	public void ShowGameOver ()
	{	
		StartCoroutine (WaitShowGameOver ());
	}

	private IEnumerator WaitShowGameOver ()
	{
		gamePlayUI.SetActive (false);
		yield return new WaitForSeconds (0.7f);
		gameOverUI.SetActive(true);
		if (!AdsManager.instance.isAds) {
			PlayCountDown ();
		}
		isCountdown = true;
		KillAllEnemy ();
		Planet.instance.GetComponent<Planet> ().enabled = false;
	}

	public void HideGameOver ()
	{	
		gameOverUI.SetActive(false);
	}
		

	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		MusicThemeManager.instance.PlayMusicMenuVsGamePLay ();
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
	}

	void Update ()
	{
		CountDown ();
	}

	public void ObjAdsUnActive ()
	{
		objAds.SetActive (false);
		objGameOverText.SetActive (true);
	}

	public void CountDown ()
	{
		if (!isCountdown) 
		{
			return;
		}

		countDownTime -= Time.deltaTime;

		if (countDownTime <= 0) {
			StopCountDown ();
			PlayMusicGameOver ();
			ObjAdsUnActive ();
		}

		countDownText.text = "" + (int)countDownTime;
	}


	public void PauseBtn ()
	{
		Time.timeScale = 0;
		containerBtns [0].SetActive (false);
		containerBtns [1].SetActive (true);
	}

	public void ResumeBtn ()
	{
		Time.timeScale = 1;
		containerBtns [0].SetActive (true);
		containerBtns [1].SetActive (false);
	}

	private void KillAllEnemy ()
	{
		foreach (Enemy enemy in enemyList) 
		{
			enemy.Destroy ();
		}
	}

	private void PlayCountDown ()
	{
		isCountdown = true;
		MusicThemeManager.instance.PlayMusicCountDown ();
	}

	private void StopCountDown ()
	{
		isCountdown = false;
		MusicThemeManager.instance.StopMusicCountDown ();
	}


	private void PlayMusicGameOver ()
	{
		if (Player.instance.currentLife <= 0) {
			MusicThemeManager.instance.PlayMusicGameOver ();
		}

	}
}
