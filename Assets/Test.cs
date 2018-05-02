using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public Transform scalePlanet;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		transform.localPosition = new Vector3 (0,transform.localPosition.y + (0.8f - scalePlanet.localScale.y)/200f,0);
	}
}
