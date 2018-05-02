using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

	public Image loadingBar;

	public float speed;

	public Planet planetScript;

	public PlayerController_RB playerScript;

	public EnemySpawner spawnerScript;

	// Use this for initialization
	void Start () {
		loadingBar.fillAmount = 0;
		planetScript.enabled = false;
		playerScript.enabled = false;
		spawnerScript.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if (loadingBar.fillAmount >= .99f) {
			StartGame ();
		} else {
			loadingBar.fillAmount += Time.deltaTime * speed;
		}

	}

	public void StartGame()
	{
		planetScript.enabled = true;
		playerScript.enabled = true;
		spawnerScript.enabled = true;
		gameObject.SetActive (false);
	}
}
