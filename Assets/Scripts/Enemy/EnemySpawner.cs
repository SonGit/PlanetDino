using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject prefab;
	public float rate;
	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn()
	{
		while (true) {

			yield return new WaitForSeconds (rate);
			GameObject enemyGo = Instantiate (prefab);
			enemyGo.transform.position = Random.insideUnitCircle * 5;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
