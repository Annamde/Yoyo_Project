using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

	public int gridPositionX;
	public int gridPositionY;
	public int size;
	/*public float gridPositionX;
	public float gridPositionY;
	public float size;*/
	public Vector3 worldPosition;
	public bool isTransitable = true;
	public bool isFull = false;

	public Node (int _gridPositionX, int _gridPositionY, int _size, Vector3 _worldPosition, bool _isTransitable, bool _isFull)
	{
		gridPositionX = _gridPositionX;
		gridPositionY = _gridPositionY;
		size = _size;
		worldPosition = _worldPosition;
		isTransitable = _isTransitable;
		isFull = _isFull;
	}

	public void Grita()
	{
		//Debug.Log ("AAAAH"+isTransitable);
		//Debug.Log(this.isFull+" "+this.gridPositionX+","+ this.gridPositionY);
	}
		
}
