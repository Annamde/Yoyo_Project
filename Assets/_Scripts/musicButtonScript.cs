using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicButtonScript : MonoBehaviour {

	public Text myText;

	public void MusicOnOff()
	{
		if (GameManager.music.isPlaying) {
			GameManager.music.Stop ();
		} 
		else if (!GameManager.music.isPlaying) {
			GameManager.music.Play ();
		}
	}
}
