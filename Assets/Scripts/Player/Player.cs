using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character {

	public static Player instance;

	[HideInInspector]
	public int currentLife;
	public static int Score = 0;
	public static int highScore;
	[HideInInspector]
	public bool isRendererPlayer;

	public bool isAddScorePerSecond;

	private float RendererPlayerTimeCount;
	private int maxLife = 3;


	Rigidbody rb;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		currentLife = maxLife;
		highScore = Score;
		Application.targetFrameRate = 30;
		Init ();
		rb = this.GetComponent<Rigidbody> ();
		rb.isKinematic = true;
		rb.velocity = Vector3.zero;;

		rb.isKinematic = false;
		StartCoroutine (AddScorePerSecond());
	}


	IEnumerator AddScorePerSecond()
	{
		isAddScorePerSecond = true;
		while (isAddScorePerSecond) {
			Score++;
			yield return new WaitForSeconds (1);
		}
	}

	// Update is called once per frame
	void Update () {

		rb.velocity = Vector3.zero;

		if (!isRendererPlayer) {
			return;
		}

		RendererPlayerTimeCount += Time.deltaTime;
	}

	void OnCollisionEnter(Collision other) {

		if (CheckIfAEnemy(other.transform)) {
			OnHitEnemy (other.transform.GetComponent<Enemy> ());
		}

	}

	void OnTriggerEnter(Collider other) {

		if (CheckIfATree(other.transform)) {
			OnHitTree ();
		}
	}

	private void OnHitEnemy(Enemy enemy)
	{
		if (currentLife <= 0) {
			return;
		}

		if (enemy.currentColor.name == currentColor.name) {
			enemy.Killed ();
			ChangeColor ();

			if (AudioManager_RB.instance != null) {
				AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.EnemyHit,transform.position);
			}

			if (!isRendererPlayer) 
			{
				ScoreUI.instance.ComboIsActive ();
				Player.Score += ScoreUI.instance.comboCount;
				ScoreUI.instance.AddScoreTextAnimation ();
			}

		}
		else 
		{

			if (isRendererPlayer) {
				if (AudioManager_RB.instance != null) {
					AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.EnemyHit,transform.position);
				}
			}

			Killed ();
			enemy.Killed ();
		}
	}

	private void ChangeColor()
	{
		int type = 0;
		switch (currentColor.name) {
		case "Character_4":
			type = 1;
			break;
		case "Character_1":
			type = 0;
			break;
		}

		currentColor = colorTextures [type];
		foreach (Renderer render in playerRenderers) {
			render.material.mainTexture = currentColor;
		}
	}

	private void OnHitTree()
	{
		Player.Score -= 5;
		ScoreUI.instance.SubtractScoreTextAnimation ();
	}

	private void Killed()
	{
		if (!isRendererPlayer) 
		{
			currentLife -= 1;

			if (currentLife > 0)
			{
				if(AudioManager_RB.instance != null)
				AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.PlayerHurt,transform.position);
				ScoreUI.instance.comboCount = 0;
				PlayerUndying ();
			}
			else
			{
				if (DataController.Instance != null) {
					GameManager.instance.objHighScore.SetActive (true);
				
					DataController.Instance.SubmitNewPlayerScore (Player.Score);

					StartCoroutine( ScreenShot.Instance.TakeScreenShot ());

					StartCoroutine (WaitDestroyPlayer());

					GameManager.instance.ShowGameOver();

					EnemySpawner.instance.PauseSpawn ();

					PlayerController_RB.instance.enabled = false;

					isAddScorePerSecond = false;

					AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.PlayerDeath,transform.position);
				}

			}
		}

	}

	private IEnumerator WaitDestroyPlayer ()
	{
		
		foreach (Renderer renderer in playerRenderers) 
		{
			yield return new WaitForSeconds (0.05f);
			renderer.gameObject.SetActive (false);
		}
	}

	private IEnumerator RendererPlayer()
	{
		isRendererPlayer = true;
		while (isRendererPlayer && RendererPlayerTimeCount < 2.9f) {
			foreach (Renderer renderer in playerRenderers) 
			{
				yield return new WaitForSeconds (0.2f);
				renderer.gameObject.SetActive (false);
				yield return new WaitForSeconds (0.2f);
				renderer.gameObject.SetActive (true);
			}
		}
		RendererPlayerTimeCount = 0;
		isRendererPlayer = false;

	}

	public void PlayerUndying ()
	{
		StartCoroutine (RendererPlayer());
	}

}
