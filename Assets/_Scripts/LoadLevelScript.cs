using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelScript : MonoBehaviour {

	public Canvas canvasGO, canvasPause;

	void Awake()
	{
		GameManager.LoadLevel (canvasGO,canvasPause);
	}
}
