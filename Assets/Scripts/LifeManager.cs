﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	public RectTransform lifeRectTransform;
	public Sprite heartEmpty;
	public Sprite heart;

	private Image[] lifeHearts;
	private int maxLives = 3;

	// Use this for initialization
	void Start () {
		lifeHearts = new Image[maxLives];

		for(int i = 0; i < maxLives; ++i)
		{
			lifeHearts[i] = lifeRectTransform.GetChild(i).GetComponent<Image>();
		}
	}
	
	// Update is called once per frame
	void UpdateLifeUI () {
		
		for (int i = 0; i < maxLives; ++i)
		{
			if(Player.instance.currentLife > i)
			{
				lifeHearts[i].sprite = heart;
			}
			else
			{
				lifeHearts[i].sprite = heartEmpty;
			}
		}
	}

	void Update ()
	{
		UpdateLifeUI ();
	}

//	public void Show()
//	{
//		gameObject.SetActive (true);
//	}
//
//	public void Hide()
//	{
//		gameObject.SetActive (false);
//	}
}
