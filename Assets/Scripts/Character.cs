﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Cacheable {

	public GameObject rendererPlace;
	
	protected Renderer[] playerRenderers;

	public Texture currentColor;

	public Texture[] colorTextures;

	protected virtual void Init()
	{
		playerRenderers = rendererPlace.GetComponentsInChildren<Renderer> ();

		if(currentColor == null)
			currentColor = playerRenderers[0].material.mainTexture;
		type = Random.Range (0,2);
		RandomColor ();
	}

	int type;
	protected void RandomColor()
	{
		if (type == 0) {
			type = 1;
		}
		else
		{
			type = 0;
		}
			
		currentColor = colorTextures [type];
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

	Tree treeCache;
	protected bool CheckIfATree(Transform targetTransform)
	{
		treeCache = targetTransform.GetComponent<Tree> ();

		if (treeCache != null)
			return true;

		return false;
	}
}
