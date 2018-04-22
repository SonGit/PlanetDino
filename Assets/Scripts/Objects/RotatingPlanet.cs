using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlanet : MonoBehaviour {
	public float speed;
	public Transform center;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(Vector3.zero, new Vector3(0,0,1), speed * Time.deltaTime);
		transform.LookAt (center,Vector3.up);
	}
}
