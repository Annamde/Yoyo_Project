using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

	public Node currentNode, nextNode;
	private myGrid grid;

	// Use this for initialization
	void Start () {
		grid = GameManager.grid;
		currentNode = grid.GetNodeContainingPosition (transform.position);
		transform.position = currentNode.worldPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement()
	{
		nextNode = grid.GetNeighboursDown (currentNode);
		transform.position = nextNode.worldPosition;

	}
}
