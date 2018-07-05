using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorScript : MonoBehaviour {

	public GameObject brick;

	private GameObject b;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("BrickCreator",1.0f,3.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void BrickCreator()
	{
		b = Instantiate (brick);
		b.transform.position = new Vector3(Random.Range(this.transform.position.x-3, this.transform.position.x+3), this.transform.position.y, this.transform.position.z);
	}
}
