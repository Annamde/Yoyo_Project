﻿using System.Collections;
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

	public void Reintentar(int index)
	{
		SceneManager.LoadScene (index);
		Time.timeScale = 1;
	}
}
