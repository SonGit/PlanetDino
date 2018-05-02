using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

	private Button m_Button;
	private string gameId = "1770286";
	private string placementId = "rewardedVideo";

	void Start ()
	{    
		m_Button = GetComponent<Button>();
		if (m_Button) m_Button.onClick.AddListener(ShowAd);

		//---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//

		if (Advertisement.isSupported) {
			Advertisement.Initialize (gameId, true);
		}

		//-------------------------------------------------------------------//

	}

	void Update ()
	{
		if (m_Button) m_Button.interactable = Advertisement.IsReady(placementId);
	}

	public void ShowAd ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(placementId, options);
	}

	private void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");
			Rewardplayer();

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}

	private void Rewardplayer ()
	{
		Player.instance.currentLife ++;
		GameManager.instance.HideGameOver ();
		GameManager.instance.ObjAdsUnActive ();
		GameManager.instance.gamePlayUI.SetActive (true);
		Player.instance.PlayerUndying ();
		EnemySpawner.instance.StartSpawn ();
		PlayerController_RB.instance.speed = PlayerController_RB.instance.startspeed;
		Player.instance.isAddScorePerSecond = true;
	}
		
}
