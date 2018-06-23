using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScript : MonoBehaviour {

	public Rigidbody2D myRb;
	public Vector2 impulso, direction;
	public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		myRb.velocity = speed*direction*Time.deltaTime;
		if (Input.GetKey (KeyCode.Space)) {
			//myRb.AddForce (impulso);
			myRb.velocity*=impulso.x;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Limit") {
			direction.x *= -1;
		}
	}
}
