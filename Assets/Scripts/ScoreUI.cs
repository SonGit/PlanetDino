using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreUI : MonoBehaviour {

	public static ScoreUI instance;

	public TextMeshProUGUI text;
	public TextMeshProUGUI comboText;
	public TextMeshProUGUI comboTitle;
	public TextMeshProUGUI addScoreAnchor;

	public int comboCount;
	public float comboScoreRate;



	private float comboTimeCount;
	private bool isActiveCombo;
	private bool isComboEffect;
	private RectTransform rt;
	private Vector2 startPos;

	void Awake(){
		instance = this;
	}

	void Start ()
	{
		rt = GetComponent<RectTransform>();
		startPos = rt.anchoredPosition;
    }

	void Update ()
	{
		text.text = Player.Score.ToString();

		rt.anchoredPosition = Vector2.Lerp(Vector2.zero, startPos, Planet.Size);

		ComboUpdate ();

		if (Input.GetKeyDown (KeyCode.A))
			AddScoreTextAnimation ();
	}
		
	float duration = .25f;

	public void ComboEffect(int currentCombo)
	{
		iTween.ShakeScale(comboText.gameObject,iTween.Hash("x",.2f,"y",.2f,"time",duration));
		iTween.ShakeScale(comboTitle.gameObject,iTween.Hash("x",.2f,"y",.2f,"time",duration));
		comboText.text = currentCombo + "x"; 

		Redder(comboText,currentCombo);
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

	private void ComboUpdate ()
	{
		if (!isActiveCombo)
			return;

		comboTimeCount += Time.deltaTime;

		if (comboTimeCount > comboScoreRate) {
			comboCount = 0;
			comboTimeCount = 0;
			isActiveCombo = false;
			comboTitle.gameObject.SetActive (false);
			comboText.gameObject.SetActive (false);
		}

		if (comboCount >= 2) 
		{
			if (isComboEffect) 
			{
				ComboEffect (comboCount);
				isComboEffect = false;
			}
			comboTitle.gameObject.SetActive (true);
			comboText.gameObject.SetActive (true);
		} 
		else 
		{
			comboTitle.gameObject.SetActive (false);
			comboText.gameObject.SetActive (false);
		}
	}

	public void ComboIsActive ()
	{
		isActiveCombo = true;
		isComboEffect = true;
		comboCount += 1;
		comboTimeCount = 0;
	}

	public void AddScoreTextAnimation ()
	{
		AddScoreText ast = ObjectPool.instance.GetAddScoreText ();
		ast.transform.parent = this.transform;
		ast.transform.position = addScoreAnchor.transform.position;
		ast.Live ();
		ast.Init (comboCount,text.transform);

	}
		
}
