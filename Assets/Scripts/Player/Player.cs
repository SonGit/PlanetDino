using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public static Player instance;

	public Transform playerMesh;

	public GameObject dustParticle;
	public int currentLife;
	public GameObject objectImgAnchor;

	private int maxLife = 3;

	Rigidbody rb;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	IEnumerator Start () {
		currentLife = maxLife;
		Application.targetFrameRate =30;
		Init ();
		rb = this.GetComponent<Rigidbody> ();
		rb.isKinematic = true;
		rb.velocity = Vector3.zero;;

		rb.isKinematic = false;
		yield return new WaitForSeconds (.25f);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = Vector3.zero;
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
			Planet.Score += 1;
		}
		else 
		{
			Killed ();
			enemy.Killed ();
		}
	}

	private void Killed()
	{
		currentLife -= 1;

		if (currentLife > 0)
		{
			// hit sound
		}
		else
		{
			// deathSound

			ScreenShot.Instance.PlayScreenShot ();

			DataController.Instance.SubmitNewPlayerScore (Planet.Score);

			StartCoroutine (WaitDestroyPlayer());

			GameManager.instance.ShowGameOver();

			objectImgAnchor.SetActive (false);

		}
	}

	private IEnumerator WaitDestroyPlayer ()
	{
		yield return new WaitForSeconds (0.05f);
		Destroy ();
	}



}
