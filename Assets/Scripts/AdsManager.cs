using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

	public int score = 0;
	public Text scoreText;

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
		scoreText.text = " " + score;
	}

	public void ShowAd ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(placementId, options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");
			// Reward your player here.
			score += 10;

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}
		
}
