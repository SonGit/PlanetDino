using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class FinalScoreUI : MonoBehaviour {

	void Start ()
	{
		GetComponent<Text>().text = "d = <i><b>" + DataController.Instance.GetHighestPlayerScore ().ToString ("0.#") + "</b>m</i>";
	}

}
