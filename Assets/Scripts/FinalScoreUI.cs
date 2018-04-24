using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FinalScoreUI : MonoBehaviour {

	void Update ()
	{
		//GetComponent<Text>().text = "d = <i><b>" + DataController.Instance.GetHighestPlayerScore ().ToString ("0.#") + "</b>m</i>";
		GetComponent<TextMeshProUGUI>().text = "" + DataController.Instance.GetHighestPlayerScore ().ToString();
	}

}
