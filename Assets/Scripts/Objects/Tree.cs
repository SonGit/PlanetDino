using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	public Transform planetScale;

	private float startScale;
	private float deltaScale;
	Transform t;
	MeshRenderer mesh;

	// Use this for initialization
	void Start () {
		planetScale = transform.parent.parent.transform;
		startScale = planetScale.localScale.x;
		mesh = this.GetComponentInChildren<MeshRenderer> ();
		t = transform;
	}
	
	// Update is called once per frame
	void Update () {
		deltaScale = startScale - planetScale.localScale.x;
		t.localScale = new Vector3 (startScale + deltaScale,startScale + deltaScale,startScale + deltaScale);
		mesh.transform.localPosition = new Vector3 (0, 0, 0.888f);
	}

	void OnTriggerEnter(Collider other) {

		iTween.ShakePosition(mesh.gameObject,iTween.Hash("x",0.2f,"time",1.0f));

	}
}
