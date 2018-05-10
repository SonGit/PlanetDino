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
	int totalSpawn = 1;
	IEnumerator Spawn()
	{
		while (isSpawn) {
			yield return new WaitForSeconds (rate);
			if (totalEnemy < 15) {
				Enemy enemyGo = ObjectPool.instance.GetEnemy ();
				enemyGo.Live ();

				if (totalSpawn % 2 == 0) {
					enemyGo.RandomColor (0);
				} else {
					enemyGo.RandomColor (1);
				}



				Vector3 pos = RandomPoint ();
				enemyGo.transform.position = pos;
				Rigidbody rb = enemyGo.GetComponent<Rigidbody> ();
				rb.velocity = Vector3.zero;
				GameManager.instance.enemyList.Add (enemyGo);
				totalSpawn++;
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
		return Random.onUnitSphere * 5.5f;

	}



}
