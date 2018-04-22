using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	public Transform planetScale;

	private float startScale;

	Transform t;

	// Use this for initialization
	void Start () {
		planetScale = transform.parent.parent.transform;
		startScale = planetScale.localScale.x;
		t = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		iTween.ShakePosition(gameObject,iTween.Hash("x",0.2f,"time",1.0f));

	}
}
