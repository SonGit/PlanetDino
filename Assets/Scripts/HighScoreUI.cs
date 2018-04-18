using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class HighScoreUI : MonoBehaviour {

	void Start ()
	{
		GetComponent<Text> ().text = "HighScore = <i><b>" + DataController.Instance.GetHighestPlayerScore ().ToString ("0.#") + "</b>m</i>";
	}

}
