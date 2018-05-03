using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public static EnemySpawner instance;

	public float rate;
	public Transform anchor;
	public Transform center;
	[HideInInspector]
	public bool isSpawn;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		StartSpawn ();
		InvokeRepeating ("CheckTotalEnemy",0,1);
	}

	public void StartSpawn ()
	{
		isSpawn = true;
		StartCoroutine (Spawn());
	}

	public void PauseSpawn ()
	{
		isSpawn = false;
	}

	int totalEnemy = 0;

	IEnumerator Spawn()
	{
		while (isSpawn) {
			yield return new WaitForSeconds (rate);
			if (totalEnemy < 12) {
				Enemy enemyGo = ObjectPool.instance.GetEnemy ();
				enemyGo.Live ();
				Vector3 pos = RandomPoint ();
				enemyGo.transform.position = pos;
				Rigidbody rb = enemyGo.GetComponent<Rigidbody> ();
				rb.velocity = Vector3.zero;
				GameManager.instance.enemyList.Add (enemyGo);
			}
		}
	}

	void CheckTotalEnemy()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		totalEnemy = enemies.Length;
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
