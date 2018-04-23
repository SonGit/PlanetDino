using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public Transform playerMesh;

	public GameObject dustParticle;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
		Init ();
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
	
		}
	}

}
