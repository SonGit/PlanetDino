using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject prefab;
	public float rate;
	public FakeGravity fakeGrav;
	// Use this for initialization
	void Start () {
		fakeGrav = this.GetComponent<FakeGravity> ();
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn()
	{
		while (true) {

			yield return new WaitForSeconds (rate);
			GameObject enemyGo = Instantiate (prefab);
			FakeGravityBody gavBody = enemyGo.GetComponent<FakeGravityBody> ();
			gavBody.attractor = fakeGrav;
			enemyGo.transform.position = Random.insideUnitCircle * 15;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
