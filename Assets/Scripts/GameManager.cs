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

	private float countDownTime = 10;
	private bool isCountdown;


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
		yield return new WaitForSeconds (0.5f);
		isCountdown = true;
		gameOverUI.SetActive(true);
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

	public void ObjAdsUnActive ()
	{
		objAds.SetActive (false);
		objGameOverText.SetActive (true);
	}


}
