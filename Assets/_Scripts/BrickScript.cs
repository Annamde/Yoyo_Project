using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

	public Node currentNode, nextNode;
	public float speed;
	public Rigidbody2D myRb;

	private Vector3 nextPos;
	private myGrid grid;

	// Use this for initialization
	void Start () {
		grid = GameManager.grid;
		currentNode = grid.GetNodeContainingPosition (transform.position);
		transform.position = currentNode.worldPosition;
		nextNode = grid.GetNeighboursDown (currentNode);
		nextPos = nextNode.worldPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement()
	{
		//transform.position = nextNode.worldPosition;
		currentNode = grid.GetNodeContainingPosition (transform.position);
		if (currentNode == nextNode) {
			nextNode = grid.GetNeighboursDown (currentNode);
			nextPos = nextNode.worldPosition;
			Debug.Log ("EEEEEEEOOOOOOO");
		}
		transform.position = Vector3.MoveTowards (transform.position, nextPos, speed * Time.deltaTime);
		Debug.Log (nextPos+transform.position);
	}

	void Die()
	{
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Out") {
			Die ();
		}
	}
}
