using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character {

	public static Player instance;


	public GameObject dustParticle;
	public int currentLife;
	public GameObject objectImgAnchor;
	public static int Score = 0;
	public static int highScore;
	[HideInInspector]
	public bool isRendererPlayer;

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
		while (true) {
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

				objectImgAnchor.SetActive (false);

			}
		}

	}

	private IEnumerator WaitDestroyPlayer ()
	{
		yield return new WaitForSeconds (0.05f);
		Destroy ();
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


	public void ExplosionEffect (Vector3 pos)
	{
		Explosion explosion;


		print (currentColor.name);

		switch (currentColor.name) {

		case "Character_1":
			explosion = ObjectPool.instance.GetExplosion1 ();
			break;
		case "Character_2":
			explosion = ObjectPool.instance.GetExplosion2 ();
			break;
		case "Character_3":
			explosion = ObjectPool.instance.GetExplosion3 ();
			break;
		case "Character_4":
			explosion = ObjectPool.instance.GetExplosion4 ();
			break;

		default:
			explosion = ObjectPool.instance.GetExplosion4 ();
			break;
		}

		if (explosion != null) {
			explosion.transform.position = pos;
			explosion.Live ();
			explosion.Play ();
		}

	}


}
