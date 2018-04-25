using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float rate;
	public Transform anchor;
	public Transform center;

	// Use this for initialization
	void Start () {

		StartCoroutine (Spawn());
	}

	IEnumerator Spawn()
	{
		while (true) {
			yield return new WaitForSeconds (rate);
			Enemy enemyGo = ObjectPool.instance.GetEnemy ();
			enemyGo.Live ();
			Vector3 pos = RandomPoint ();
			enemyGo.transform.position = pos;
			Rigidbody rb = enemyGo.GetComponent<Rigidbody> ();
			rb.velocity = Vector3.zero;
		}
	}

	float distanceToCenter;

	Vector3 RandomPoint()
	{
		float distanceToCenter = Vector3.Distance (anchor.position,center.position);

		Vector3 pos = Random.insideUnitSphere * 5.5f;

		while (Vector3.Distance (pos, center.position) < distanceToCenter) {
			pos = Random.insideUnitSphere * 5.5f;
		}
		return pos;

	}



}
