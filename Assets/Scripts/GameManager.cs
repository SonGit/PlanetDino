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
	public List<Enemy> enemyList;

	private float countDownTime = 10;
	private bool isCountdown;

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
		yield return new WaitForSeconds (0.5f);
		isCountdown = true;
		gameOverUI.SetActive(true);
		KillAllEnemy ();
	}

	public void HideGameOver ()
	{	
		gameOverUI.SetActive(false);
	}
		

	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
			isCountdown = false;
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

}
