using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour {


	public void Exit()
	{
		//Application.Quit ();
		GameManager.time=0;
		GameManager.coins = 0;
		SceneManager.LoadScene(0);
	}

	public void Restart(int index)
	{
		SceneManager.LoadScene (index);

		Time.timeScale = 1;
		GameManager.time = 0;
		GameManager.coins = 0;
	}

	public void Resume()
	{
		GameManager.canvasPause.enabled = false;
		Time.timeScale = 1;
	}

	public void Pause()
	{
		GameManager.ActivateCanvas (GameManager.canvasPause);
	}

	public void Activate(Canvas canvas)
	{
		GameManager.ActivateCanvas (canvas);
	}

	public void Return(Canvas canvas)
	{
		GameManager.CloseCanvas (canvas);
	}
	public void TapToPlay()
	{
		SceneManager.LoadScene (1);
	}

	public void yemyemPlay(Button myButton)
	{
		if (GameManager.yemyem <= 0) {
			myButton.gameObject.SetActive (false);
		} else {
			GameManager.yemyem--;
			SceneManager.LoadScene (1);
			Time.timeScale = 1;
		}
	}

}
