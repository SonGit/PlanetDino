using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

	public Transform target;
	public Transform center;
	public float smoothness = 1f;
	public float rotationSmoothness = .1f;

	public Vector3 offset;

	private Vector3 velocity = Vector3.zero;

	// Update is called once per frame
	void Update () {

		if (target == null)
		{
			return;
		}
		
		Vector3 newPos = target.TransformDirection(offset);
		//transform.position = newPos;
		transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothness);

		transform.LookAt(center,transform.up);

		//transform.eulerAngles = new Vector3 (transform.eulerAngles.x + 7,transform.eulerAngles.y,transform.eulerAngles.z);
	}
}
