using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreUI : MonoBehaviour {

	public TextMeshProUGUI text;
	public TextMeshProUGUI comboText;
	public TextMeshProUGUI comboTitle;

	RectTransform rt;
	Vector2 startPos;

	void Start ()
	{
		rt = GetComponent<RectTransform>();
		startPos = rt.anchoredPosition;
    }

	void Update ()
	{
		//text.text = Planet.Score.ToString("0.#") + "m";
		text.text = Planet.Score.ToString();

		rt.anchoredPosition = Vector2.Lerp(Vector2.zero, startPos, Planet.Size);

		if (Input.GetKeyDown (KeyCode.A)) {
			ComboEffect ();
		}
	}

	int i = 1;
	float duration = .25f;

	public void ComboEffect()
	{
		i++;

		iTween.ShakeScale(comboText.gameObject,iTween.Hash("x",.2f,"y",.2f,"time",duration));
		iTween.ShakeScale(comboTitle.gameObject,iTween.Hash("x",.2f,"y",.2f,"time",duration));
		comboText.text = i + "x"; 

		Redder(comboText,i);
	}

	float magnitude = 25;

	void Redder(TextMeshProUGUI text,int combo)
	{
		Color initColor = text.color;

		float r = initColor.r * 255;
		float g = 255 - combo * magnitude;
	
		if (g < 0)
			g = 0;

		text.color = new Color32 ((byte)r,(byte)g,(byte)initColor.b,(byte)255);
	}


}
