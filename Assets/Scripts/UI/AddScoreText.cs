using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddScoreText : Cacheable {

	TextMeshProUGUI textMesh;

	// Use this for initialization
	void Start () {
		
	}

	float alpha = 255;
	// Update is called once per frame
	void Update () {
		
		if (!runnning)
			return;
		
		textMesh.alpha -= 2f * Time.deltaTime;

		if (textMesh.alpha < 0) {
			runnning = false;
			Destroy ();
		}
	}

	public void Show(int score)
	{

	}

	public override void OnDestroy ()
	{
		iTween.Stop (gameObject);
		gameObject.SetActive (false);
	}

	public override void OnLive ()
	{
		gameObject.SetActive (true);
	
	}

	public void Init(int score,Transform target)
	{
		if(textMesh == null)
		textMesh = this.GetComponent<TextMeshProUGUI> ();

		gameObject.transform.localScale = Vector3.one;

		iTween.MoveTo (gameObject, iTween.Hash ("position", target.position, "time", 1.75f));

		textMesh.text = "+" + score;
		textMesh.alpha = 1;

		runnning = true;
	}

	bool runnning;
}
