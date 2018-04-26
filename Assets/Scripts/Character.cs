using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Cacheable {
	
	protected Renderer[] playerRenderers;

	public Texture currentColor;

	public Texture[] colorTextures;

	protected virtual void Init()
	{
		playerRenderers = this.GetComponentsInChildren<Renderer> ();

		if(currentColor == null)
			currentColor = playerRenderers[0].material.mainTexture;
		
		RandomColor ();
	}

	protected void RandomColor()
	{
		int random = Random.Range (0,colorTextures.Length);
		Texture newColor = colorTextures[random];

		while (newColor.name == currentColor.name) {
			random = Random.Range (0,colorTextures.Length);
			newColor = colorTextures[random];
		}

		currentColor = newColor;

		foreach (Renderer render in playerRenderers) {
			render.material.mainTexture = currentColor;
		}
	}

	public override void OnDestroy ()
	{
		gameObject.SetActive (false);
	}

	public override void OnLive ()
	{
		gameObject.SetActive (true);
		Init ();
	}
		
	Enemy enemyCache;
	protected bool CheckIfAEnemy(Transform targetTransform)
	{
		enemyCache = targetTransform.GetComponent<Enemy> ();

		if (enemyCache != null)
			return true;

		return false;
	}

	Player playerCache;
	protected bool CheckIfAPlayer(Transform targetTransform)
	{
		playerCache = targetTransform.GetComponent<Player> ();

		if (playerCache != null)
			return true;

		return false;
	}
}
