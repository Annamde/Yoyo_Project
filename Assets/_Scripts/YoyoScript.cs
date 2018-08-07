using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScript : MonoBehaviour {

	public Rigidbody2D myRb;
	public Vector2 impulso, direction, impulsoRight, impulsoLeft;
	public Vector3 empujon, positionInitial;
	public int speed;
	public float duration;
	public SpriteRenderer mySprite;

	private bool muevete;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		if (muevete) {
			StartCoroutine (Empujon (positionInitial, duration));
		}
	}

	void Move()
	{
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
		if (Input.touchCount == 1) {
			myRb.velocity*=impulso.x;
		}
	}

	public void RightMove()
	{
		if (Input.touchCount == 1) {
			//myRb.velocity *= impulsoRight.x;
			//direction = Vector2.right;
			direction.x = 1;
		}
	}

	public void LeftMove()
	{
		if (Input.touchCount == 1) {
			//myRb.velocity *= impulsoLeft.x;
			//direction=Vector2.left;
			direction.x = -1;
		}
	}

	IEnumerator Empujon (Vector3 positionInitial, float duration)
	{
		float counter = 0.0f;

		if (transform.position.y > positionInitial.y - 0.9f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
			counter += Time.deltaTime;
		} else {
			muevete = false;
		}
		yield return null;

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Limit") {
			direction.x *= -1;
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Brick")
		{
			//print (col.bounds.min.y+"   "+this.transform.position.y +"  "+ mySprite.size.y/2);
			//print (col.bounds.min.y+"   "+mySprite.bounds.center.y +"  "+ mySprite.bounds.size.y/2);
			if (col.bounds.min.y >= this.transform.position.y + mySprite.size.y/2 -0.1f) 
			{
				//transform.position+=empujon;
				muevete = true;
				positionInitial = transform.position;
				print (positionInitial);
				Destroy (col.gameObject);
			}
		}
		if (col.gameObject.tag == "Limit") {
			direction.x *= -1;
		}
		if (col.gameObject.tag == "Out") {
			GameManager.ActivateCanvas (GameManager.canvasGO);
		}
	}
}
