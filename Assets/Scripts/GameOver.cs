using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void ReStart ()
	{
		GameManager.instance.Restart();
		GetComponent<RectTransform>().localScale = Vector3.one * Planet.Size;
		Player.Score = 0;
	}

	public void Show()
	{
		gameObject.SetActive (true);
	}

	public void Hide()
	{
		gameObject.SetActive (false);
	}
}
