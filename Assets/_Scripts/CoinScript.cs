using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : ObjectScript {

	public int points;

	protected override void Start () {
		base.Start ();
	}

	protected override void Update () 
	{
		base.Update ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Out") {
			Die ();
		}
		if (col.gameObject.tag == "Yoyo") {
			GameManager.coins += points;
			Die ();
		}
	}
}
