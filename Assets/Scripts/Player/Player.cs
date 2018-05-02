using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character {

	public static Player instance;


	public GameObject dustParticle;
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

	private void OnHitEnemy(Enemy enemy)
	{
		if (enemy.currentColor.name == currentColor.name) {
			enemy.Killed ();
			RandomColor ();

			if (!isRendererPlayer) 
			{
				ScoreUI.instance.ComboIsActive ();
				Player.Score += ScoreUI.instance.comboCount;
				ScoreUI.instance.AddScoreTextAnimation ();
			}

		}
		else 
		{
			Killed ();
			enemy.Killed ();

		}
	}


	private void Killed()
	{
		if (!isRendererPlayer) 
		{
			currentLife -= 1;

			if (currentLife > 0)
			{
				// hit sound
				ScoreUI.instance.comboCount = 0;
				PlayerUndying ();

			}
			else
			{
				// deathSound

				ScreenShot.Instance.PlayScreenShot ();

				DataController.Instance.SubmitNewPlayerScore (Player.Score);

				StartCoroutine (WaitDestroyPlayer());

				GameManager.instance.ShowGameOver();

				EnemySpawner.instance.PauseSpawn ();

				PlayerController_RB.instance.speed = 0f;

				isAddScorePerSecond = false;
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
