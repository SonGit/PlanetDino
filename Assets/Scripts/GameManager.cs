using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject gameOverUI;

	void Awake ()
	{
		instance = this;
	}

	private IEnumerator WaitEndGame ()
	{
		yield return new WaitForSeconds (2);
		gameOverUI.SetActive(true);
	}

	public void EndGame ()
	{	
		StartCoroutine (WaitEndGame());
	}

	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
