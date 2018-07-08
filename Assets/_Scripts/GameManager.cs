using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static myGrid grid;
	private float count;
	public static int score;
	public Text scoreText;
	public Canvas canvasGO;

	// Use this for initialization
	void Start()
	{
		count = 0;
		canvasGO.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		count = count + Time.deltaTime;
		score = (int)count;
		SetScoreText();
	}

	public static void SetGrid(myGrid _grid)
	{
		grid = _grid;
	}
	void SetScoreText()
	{
		scoreText.text = score.ToString();
	}
	public static void GameOver(Canvas canvas)
	{
		canvas.enabled = true;
		Time.timeScale = 0;
	}
}
