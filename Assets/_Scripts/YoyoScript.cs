using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScript : MonoBehaviour {

	public Rigidbody2D myRb;
	public Vector2 impulso, direction;
	public Vector3 empujon, positionInitial;
	public int speed, maxSpeed;
	public SpriteRenderer mySprite;
	public bool right, left;

	private bool muevete;
	private float counterStay;
	private int initialSpeed;

	// Use this for initialization
	void Start () {
		initialSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		if (muevete) {
			StartCoroutine (Empujon (positionInitial));
		}
		//print (myRb.velocity);
		//print(speed);
		RegularDireccion();
	}

	void Move()
	{
		myRb.velocity = speed*direction*Time.deltaTime;
		Impulse ();

	}

	void Impulse()
	{
		if (Input.GetKey (KeyCode.Space)) {
			myRb.velocity*=impulso.x;
		}

		if (Input.touchCount == 1 || Input.GetMouseButton(0)) {
			speed = maxSpeed;
			if (right) {
				left = false;
				//si es positivo seguir asi, si es falso cambiar a positivo
				if (myRb.velocity.x >= 0) {
					myRb.velocity *= impulso.x;
				}
				if (myRb.velocity.x < 0) {
					myRb.velocity *= -impulso.x;
				}
			}
			else if (left) {
				right = false;
				//si es negativo impulsar hacia alli, si es positivo cambiar a negativo
				if (myRb.velocity.x >= 0) {
					myRb.velocity *= -impulso.x;
				}
				if (myRb.velocity.x < 0) {
					myRb.velocity *= impulso.x;
				}
			}
		}
		if (Input.touchCount == 0) { //no funciona con el raton recuerda
			right = false;
			left = false;
			speed = initialSpeed;
		}
	}

	//BOTONES QUE YA NO UTILIZO
	/*public void RightMove()
	{
		if (Input.touchCount == 1) {
			//myRb.velocity *= impulsoRight.x;
			//direction = Vector2.right;
			//direction.x = 1;
			//transform.position += new Vector3 (transform.position.x + 0.0001f, 0, 0);
		}
	}

	public void LeftMove()
	{
		if (Input.touchCount == 1) {
			//myRb.velocity *= impulsoLeft.x;
			//direction=Vector2.left;
			//direction.x = -1;
			//transform.position += new Vector3 (transform.position.x - 0.0001f,0, 0);
		}
	}*/
	/// <summary>
	/// Regulars the direccion.
	/// </summary>
	public void RegularDireccion()
	{
		if (counterStay > 0.2f) {
			direction *= -1;
		}
	}

	/// <summary>
	/// Empujon the specified positionInitial.
	/// </summary>
	/// <param name="positionInitial">Position initial.</param>
	IEnumerator Empujon (Vector3 positionInitial)
	{
		if (transform.position.y > positionInitial.y - 0.9f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
		} else {
			muevete = false;
		}
		yield return null;

	}

	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Limit") {
			right = false;
			left = false;
			if (direction.x == 1) {
				direction.x = -1;
			} else if (direction.x == -1) {
				direction.x = 1;
			}
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
				Destroy (col.gameObject);
			}
		}
		if (col.gameObject.tag == "Limit") {
			if (direction.x == 1) {
				direction.x = -1;
			} else if (direction.x == -1) {
				direction.x = 1;
			}

			//direction.x *= -1;
		}
		if (col.gameObject.tag == "Out") {
			GameManager.ActivateCanvas (GameManager.canvasGO);
		}
	}
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Limit") {
			counterStay += Time.deltaTime;
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Limit") {
			counterStay = 0;
		}
	}
}
