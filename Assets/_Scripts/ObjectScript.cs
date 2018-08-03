using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

	public Node currentNode, nextNode;
	public float speed;

	private Vector3 nextPos;
	private myGrid grid;


	// Use this for initialization
	protected virtual void Start () {
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
	protected virtual void Update () 
	{
		Movement ();
	}

	virtual public void Movement() //el virtual hace que cualquier hijo pueda sobreescribirla si quiere (poniendo override)
	{
		currentNode = grid.GetNodeContainingPosition (transform.position);
		currentNode.isFull = false;
		if (currentNode == nextNode) {
			currentNode.isFull = false;
			nextNode = grid.GetNeighboursDown (currentNode);
			nextPos = nextNode.worldPosition;
		}
		transform.position = Vector3.MoveTowards (transform.position, nextPos, speed * Time.deltaTime);
	}

	public void IncrementSpeed()
	{

	}

	public void CorrectPosition()
	{
		if (currentNode.isFull == true) {
			Die ();
		}
	}

	public void Die()
	{
		Destroy (this.gameObject);
	}
}
