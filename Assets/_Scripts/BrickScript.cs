﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : ObjectScript {


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
			//Die ();
			//en un futuro hacer que los brick parpaden o hacer algo guay para que desaparezcan
		}
	}
}
