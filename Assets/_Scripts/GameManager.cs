using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	public static myGrid grid;
	public static int score, coins, yemyem = 1, highScore;
	public static float time=0;
	public static Canvas canvasGO, canvasPause, canvasSettings, canvasShop, canvasRanking;
	public static YoyoScript yoyo;
	public static Text scoreText, puntosCanvasText, coinsText, coinsCanvasText, highScoreText, musicText, scoreTextMenu;
	public static AudioSource music;
	public static GameManager instance=null;
	public static GameObject generator;

	private float counter;
	private bool create;


	void Awake()
	{
		if (instance==null) {
			instance = this;
		} 
		else if(instance != this)
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}
		
	// Use this for initialization
	void Start()
	{
		//highScoreText.text = PlayerPrefs.GetInt ("HighScore",0).ToString();
		PlayerPrefs.GetInt("HighScore",highScore);

		music = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update()
	{
		print (highScore+"  "+score);
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			
			score = (int)time;
			SetText (scoreText, score);
			SetText (puntosCanvasText, score);
			SetText (coinsText, coins);
			SetText (coinsCanvasText, coins);

			if (canvasGO.enabled == true) {
				yoyo.mySprite.enabled = false;
				Time.timeScale = 1;
				counter += Time.deltaTime;
				if (counter >= 7) {
					counter = 0;
					CloseCanvas (canvasGO);
					SceneManager.LoadScene (0);
				}
				if (highScore < score) {
					highScore = score;
				} else {
					highScore = highScore;
				}
				PlayerPrefs.SetInt ("highScore", highScore);
			}
			else if (canvasGO.enabled == false) {
				generator.SetActive (true);
				time += Time.deltaTime;
			}
		}

		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			MusicTextUpdate ();
			SetText (highScoreText, highScore);
			SetText (scoreTextMenu, score);
		}
	}

	void MusicTextUpdate()
	{
		if (music.isPlaying) {
			musicText.text = "On";
		} 
		else if (!music.isPlaying) {
			musicText.text = "Off";
		}
	}

	public static void LoadLevel(Canvas _canvasGO, Canvas _canvasPause, YoyoScript _yoyo, Text _scoreText, Text _puntosCanvasText, Text _coinsText, Text _coinsCanvasText, GameObject _generator)
	{
		canvasGO = _canvasGO;
		canvasPause = _canvasPause;
		yoyo = _yoyo;
		scoreText = _scoreText;
		puntosCanvasText = _puntosCanvasText;
		coinsText = _coinsText;
		coinsCanvasText = _coinsCanvasText;
		generator = _generator;
	}

	public static void LoadMenu (Canvas _canvasSetting, Canvas _canvasShop, Canvas _canvasRanking, Text _highScoreText, Text _musicText, Text _scoreTextMenu)
	{
		canvasSettings = _canvasSetting;
		canvasShop = _canvasShop;
		canvasRanking = _canvasRanking;
		highScoreText = _highScoreText;
		musicText = _musicText;
		scoreTextMenu = _scoreTextMenu;
	}

	public static void SetGrid(myGrid _grid)
	{
		grid = _grid;
	}
	void SetText(Text texto, int puntos)
	{
		texto.text = puntos.ToString();
	}
	public static void ActivateCanvas(Canvas canvas)
	{
		canvas.enabled = true;
		Time.timeScale = 0;
	}
	public static void CloseCanvas(Canvas canvas)
	{
		canvas.enabled = false;
		Time.timeScale = 1;
	}
}
