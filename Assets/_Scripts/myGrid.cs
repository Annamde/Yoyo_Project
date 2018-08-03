using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGrid : MonoBehaviour { 
	public int size_x, size_y;

	public Node[,] grid; //da igual que sea public, no lo va a mostrar por el inspector
	//guarda en memoria el espacio

	public int node_size = 1;
	//public float node_size;

	void Awake ()
	{
		GenerateGrid ();
		GameManager.SetGrid (this);
	}

	public void GenerateGrid()
	{
		grid = new Node[size_x, size_y]; 

		for (int i = 0; i < size_x; i++) {
			for (int j = 0; j < size_y; j++) {
				

				Vector3 nodePosition = new Vector3 (node_size * 0.5f + i * node_size, node_size * 0.5f + j * node_size, 0);
				Vector3 worldNodePosition = transform.position + nodePosition;

				Collider[] colliders = Physics.OverlapSphere (worldNodePosition, node_size * 0.5f);

				bool isTransitable = true;
				for (int k = 0; k < colliders.Length; k++) {
					if (colliders [k].tag == "Limite") {
						isTransitable = false;
						Debug.Log (i +" "+k);
					}
				}
				grid [i, j] = new Node (i, j, node_size, worldNodePosition, isTransitable, false); 
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (grid != null) 
		{
			Gizmos.color = Color.green;

			for (int i = 0; i < grid.GetLength(0); i++) 
			{
				for (int j = 0; j < grid.GetLength(1); j++) 
				{
					Vector3 position = new Vector3 (node_size*0.5f + i*node_size, node_size*0.5f + j*node_size, 0); //la mutiplicacion es mas barata que la division
					Vector3 scale = new Vector3 (node_size, node_size, node_size);

					Gizmos.DrawWireCube (grid[i,j].worldPosition, scale);

				}
			}
		}
	}
		
	public Node GetNode(int x, int y)
	{

		if (x < 0 || y < 0 || x > size_x || y > size_y) {
			Debug.LogWarning ("SE HA PEDIDO UN NODO NO VALIDO en la posicion "+ x +", " + y);
			return null;
		}
		return grid[x,y];
	}


	public Node GetNodeContainingPosition(Vector3 worldPosition)
	{
		Vector3 localPosition = worldPosition - transform.position;

		int x = Mathf.FloorToInt(localPosition.x/node_size);
		int y = Mathf.FloorToInt(localPosition.y/node_size);

		if (x < size_x && x >= 0 && y < size_y && y >= 0) 
		{
			return grid [x, y];
		}
		return null;
	}

	public List<Node> GetNeighbours(Node node, bool extended)
	{
		List<Node> listNodosADevolver = new List<Node> ();

		for (int i = -1; i < 1; i++) {
			for (int j = -1; j < 1; j++) {

				if (!extended) 
				{
					if (Mathf.Abs(i) == Mathf.Abs(j))
						continue;
				} 
				else 
				{
					if (i == 0 && j == 0)
						continue;
				}

				Node vecino = GetNode(node.gridPositionX + i, node.gridPositionY + j);
				if (vecino != null) {
					listNodosADevolver.Add (vecino);
				}
			}
		}
		return listNodosADevolver;
	}

	public Node GetNeighboursDown(Node node)
	{
		Node neighbourd = GetNode (node.gridPositionX, node.gridPositionY - node_size);
		//print (neighbourd);
		return neighbourd;
	}
		
}

