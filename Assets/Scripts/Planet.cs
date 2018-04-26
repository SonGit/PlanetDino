using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	public static float Size
	{
		get { return myTransform.localScale.x; }
	}
		
	private static Transform myTransform;

	public float shrinkSpeed = .05f;

	public float minSize;

	void Awake ()
	{
		myTransform = transform;
	}

	void Update ()
	{
		if (transform.localScale.x > minSize) {
			transform.localScale *= 1f - shrinkSpeed * Time.deltaTime;
		}
	}

}
