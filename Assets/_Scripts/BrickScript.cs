using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

	public Node currentNode, nextNode, pastNode;
	public float speed;

	private Vector3 nextPos;
	private myGrid grid;


	// Use this for initialization
	void Start () {
		grid = GameManager.grid;
		currentNode = grid.GetNodeContainingPosition (transform.position);
		transform.position = currentNode.worldPosition;
		nextNode = grid.GetNeighboursDown (currentNode);
		nextPos = nextNode.worldPosition;
		currentNode.Grita ();
		CorrectPosition ();
		currentNode.isFull = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
	}

	void Movement()
	{
		//transform.position = nextNode.worldPosition;
		currentNode = grid.GetNodeContainingPosition (transform.position);
		currentNode.isFull = false;
		if (currentNode == nextNode) {
			currentNode.isFull = false;
			nextNode = grid.GetNeighboursDown (currentNode);
			nextPos = nextNode.worldPosition;
		}
		transform.position = Vector3.MoveTowards (transform.position, nextPos, speed * Time.deltaTime);
	}

	void IncrementSpeed()
	{
		
	}

	public void CorrectPosition()
	{
		if (currentNode.isFull == true) {
			Die ();
			//print ("malaaa posicioon");
		}
	}

	public void Die()
	{
		Destroy (this.gameObject);
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
