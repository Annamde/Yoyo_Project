using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Exit()
	{
		Application.Quit ();
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
}
