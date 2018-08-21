using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MovementScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public UnityEvent OnHold;
	bool IsHolding;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (IsHolding) {
			OnHold.Invoke ();
		}
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		IsHolding = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		IsHolding = false;
	}

	public void RightButton()
	{
		GameManager.yoyo.right = true;
		//GameManager.yoyo.RightMove ();
	}

	public void LeftButton()
	{
		GameManager.yoyo.left = true;
		//GameManager.yoyo.LeftMove ();
	}
}
