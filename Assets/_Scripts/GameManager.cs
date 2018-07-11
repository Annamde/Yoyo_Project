using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static myGrid grid;
	public static int score;
	public static float time;
	public Text scoreText, puntosText;
	public Canvas canvasGO;


	// Use this for initialization
	void Start()
	{
		time = 0;
		canvasGO.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		time = time + Time.deltaTime;
		score = (int)time;
		SetScoreText(scoreText);
		SetScoreText (puntosText);
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
