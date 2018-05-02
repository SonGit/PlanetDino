using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	public Transform planetScale;

	private float startScale;

	MeshRenderer mesh;

	// Use this for initialization
	void Start () {
		planetScale = transform.parent.parent.transform;
		startScale = planetScale.localScale.x;
		mesh = this.GetComponentInChildren<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		iTween.ShakePosition(mesh.gameObject,iTween.Hash("x",0.2f,"time",1.0f));

	}
}
