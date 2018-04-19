using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform playerMesh;

	public GameObject dustParticle;

	// Use this for initialization
	IEnumerator Start () {
		GameObject dustGO;
		while (true) {
			dustGO = Instantiate (dustParticle);
			dustGO.transform.position = transform.position;
			dustGO.transform.eulerAngles = transform.eulerAngles * -1;
			yield return new WaitForSeconds (1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
