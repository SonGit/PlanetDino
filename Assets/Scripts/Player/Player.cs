using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public Transform playerMesh;

	public GameObject dustParticle;

	Rigidbody rb;

	// Use this for initialization
	IEnumerator Start () {
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
		}
		else 
		{
			enemy.Killed ();
		}
	}

}
