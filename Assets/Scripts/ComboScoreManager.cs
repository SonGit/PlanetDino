using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScoreManager : MonoBehaviour {

	public static ComboScoreManager instance;

	private Text ComboScoreText;

	public int comboScoreCount;
	public float comboScoreTimeCount;
	public float comboScoreRate;
	public bool isActiveComboScore;

	void Awake(){
		instance = this;
	}

	void Start ()
	{
		ComboScoreText = GetComponent<Text> ();
	}

	void Update ()
	{
		if (!isActiveComboScore)
			return;
		
		comboScoreTimeCount += Time.deltaTime;

		if (comboScoreTimeCount > comboScoreRate) {
			comboScoreCount = 0;
			comboScoreTimeCount = 0;
			isActiveComboScore = false;
		}

		if (comboScoreCount >= 3) 
		{
			GetComboScore ("x3");
			if (comboScoreCount >= 4) 
			{
				GetComboScore ("x4");
			}
		} 
		else 
		{
			GetComboScore ("");
		}

	}

	public void GetComboScore(string comboText){
		ComboScoreText.text = comboText;
	}

}
