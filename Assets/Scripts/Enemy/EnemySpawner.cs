using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

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
			Enemy enemyGo = ObjectPool.instance.GetEnemy ();
			enemyGo.transform.position = Random.insideUnitSphere * 15;
			FakeGravityBody gavBody = enemyGo.GetComponent<FakeGravityBody> ();
			gavBody.attractor = fakeGrav;
			enemyGo.Live ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}




}
