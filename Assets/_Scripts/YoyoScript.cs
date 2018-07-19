using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScript : MonoBehaviour {

	public Rigidbody2D myRb;
	public Vector2 impulso, direction;
	public Vector3 empujon;
	public int speed;
	public Canvas gameOver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Input.touchCount);

		myRb.velocity = speed*direction*Time.deltaTime;
		if (Input.GetKey (KeyCode.Space)) {
			//myRb.AddForce (impulso);
			myRb.velocity*=impulso.x;
		}
		/*foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began ) { 
				myRb.velocity*=impulso.x;//pequeño impulso hacia el lado en el que va
				print("EEEOOOO");

			}
			if (touch.phase != TouchPhase.Ended) {
				print ("FINIQUITAOTAOOOO");
			}
		}*/
		if (Input.touchCount >= 1) {
			myRb.velocity*=impulso.x;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Limit") {
			direction.x *= -1;
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Brick") {
			//myRb.AddForce (empujon);
			transform.position+=empujon;
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Limit") {
			direction.x *= -1;
		}
		if (col.gameObject.tag == "Out") {
			GameManager.ActivateCanvas (gameOver);
		}
	}
}
