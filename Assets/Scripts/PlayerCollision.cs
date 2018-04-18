using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public GameObject deathEffect;

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Meteor")
		{
			ScreenShot.Instance.PlayScreenShot ();

			DataController.Instance.SubmitNewPlayerScore (Planet.Score);

			StartCoroutine (WaitDestroyPlayer());

			GameManager.instance.EndGame();

			AudioManager.instance.Play("PlayerDeath");

		}
	}

	private IEnumerator WaitDestroyPlayer ()
	{
		yield return new WaitForSeconds (0.05f);
		Instantiate(deathEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
