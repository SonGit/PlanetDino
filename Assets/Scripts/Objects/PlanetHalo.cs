using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetHalo : MonoBehaviour {

	public Transform planetScale;
	Transform t;
	// Use this for initialization
	void Start () {
		t = transform;
	}
	float scale;
	// Update is called once per frame
	void Update () {
		scale = (planetScale.localScale.x * 110) / 0.8f;
		t.localScale = new Vector3 (scale,scale,scale);
	}
}
