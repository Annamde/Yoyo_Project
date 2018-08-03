using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorScript : MonoBehaviour {

	public BrickScript brick;

	private BrickScript b;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("BrickCreator",1.0f,3.0f);

		InvokeRepeating ("BrickCreator", 75f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void BrickCreator()
	{
		b = Instantiate (brick);

		b.transform.position = new Vector3(Random.Range(this.transform.position.x-2, this.transform.position.x+2), this.transform.position.y, this.transform.position.z);

	}
}
