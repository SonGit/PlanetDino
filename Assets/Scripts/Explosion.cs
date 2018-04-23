using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Cacheable {

	private ParticleSystem[] particles;

	private float timeCount = 0;

	// Use this for initialization
	void Start () {
		Destroy ();
	}



	// Update is called once per frame
	void Update () {
		if (!_isInPool)
			return;
		
		timeCount += Time.deltaTime;
		if (timeCount > 0.7f) {
			timeCount = 0;
			Destroy ();
		}

	}

	public override void OnDestroy ()
	{
		gameObject.SetActive (false);
	}
		
	public override void OnLive ()
	{
		gameObject.SetActive (true);
	}

	public void Play()
	{
		particles = this.GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem particle in particles) {
			particle.Play ();
		}
	}
}
