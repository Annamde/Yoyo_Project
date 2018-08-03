﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static myGrid grid;
	public static int score, coins;
	public static float time=0;
	public static Canvas canvasGO, canvasPause;
	public static YoyoScript yoyo;
	public Text scoreText, puntosText;


	// Use this for initialization
	void Start()
	{
		canvasGO.enabled = false;
		canvasPause.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		time += Time.deltaTime;
		score = (int)time + coins;
		SetScoreText(scoreText);
		SetScoreText (puntosText);
	}

	public static void LoadLevel(Canvas _canvasGO, Canvas _canvasPause, YoyoScript _yoyo)
	{
		canvasGO = _canvasGO;
		canvasPause = _canvasPause;
		yoyo = _yoyo;
	}

	public static void SetGrid(myGrid _grid)
	{
		grid = _grid;
	}
	void SetScoreText(Text texto)
	{
		texto.text = score.ToString();
	}
	public static void ActivateCanvas(Canvas canvas)
	{
		canvas.enabled = true;
		Time.timeScale = 0;
	}
}
