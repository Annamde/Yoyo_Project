using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelScript : MonoBehaviour {

	public Canvas canvasGO, canvasPause;
	public YoyoScript yoyo;
	public Text scoreText, puntosCanvasText, coinsText, coinsCanvasText;
	public GameObject generator;

	void Awake()
	{
		GameManager.LoadLevel (canvasGO,canvasPause,yoyo,scoreText, puntosCanvasText, coinsText, coinsCanvasText, generator);
		canvasGO.enabled = false;
		canvasPause.enabled = false;
		GameManager.time = 0;
		GameManager.coins = 0;
	}
}
