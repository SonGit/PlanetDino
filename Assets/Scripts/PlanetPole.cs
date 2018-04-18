using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPole : MonoBehaviour {

	public Renderer skybox;

	public Transform player;

	public Transform planet;

	public float distanceToDark;

	private Material matCache;

	// Use this for initialization
	void Start () {
		matCache = skybox.material;
	}

	float maxDistance;
	// Update is called once per frame
	void FixedUpdate () {
		distanceToDark = Vector3.Distance (transform.position,player.position);

		maxDistance = (planet.localScale.x * 8.5f) / 0.8f;

		float alpha = (distanceToDark * 255) / maxDistance;

		matCache.color = new Color32 (0,0,0, (byte)(255 -alpha));

		print (alpha);
	}
}
