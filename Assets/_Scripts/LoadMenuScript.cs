using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenuScript : MonoBehaviour {

	public Canvas canvasSettings, canvasShop, canvasRanking;
	public Text highScoreText, musicText, scoreText;

	void Awake()
	{
		GameManager.LoadMenu (canvasSettings, canvasShop, canvasRanking,highScoreText, musicText,scoreText);
		canvasSettings.enabled = false;
		canvasShop.enabled = false;
		canvasRanking.enabled = false;
	}
}
