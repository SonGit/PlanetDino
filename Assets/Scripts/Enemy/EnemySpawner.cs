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
			enemyGo.Live ();
			Vector3 pos = Random.insideUnitSphere * 5.5f;
			enemyGo.transform.position = pos;
			Rigidbody rb = enemyGo.GetComponent<Rigidbody> ();
			rb.velocity = Vector3.zero;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}




}
