using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void ReStart ()
	{
		GameManager.instance.Restart();
		GetComponent<RectTransform>().localScale = Vector3.one * Planet.Size;
		Planet.Score = 0;
	}

}
