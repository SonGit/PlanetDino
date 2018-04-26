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
		
		textMesh.alpha -= 1.5f * Time.deltaTime;

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

	public void Init(int score)
	{
		if(textMesh == null)
		textMesh = this.GetComponent<TextMeshProUGUI> ();

		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = new Vector3 (-12,-120,0);
		iTween.MoveBy (gameObject, iTween.Hash ("y", 80, "time", 1.75f,"islocal",true));

		textMesh.text = "+" + score;
		textMesh.alpha = 1;

		runnning = true;
	}

	bool runnning;
}
