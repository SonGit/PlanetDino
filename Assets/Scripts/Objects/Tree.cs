﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.ShakePosition(gameObject,iTween.Hash("x",0.3f,"time",1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
