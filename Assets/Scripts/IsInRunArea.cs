using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInRunArea : MonoBehaviour {

	GameObject[] controllers;
	public float left = -100f;
	public float right = -40;

// Use this for initialization
	void Start () {
		controllers = GameObject.FindGameObjectsWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		float x;
		foreach ( GameObject c in controllers ) {
			x = c.transform.position.x;
			if ( left < x && x < right ) {
				if ( c.name.Equals("Move (Horizontal)") ) {
					c.GetComponent<MovePlayerHorizontal>().enabled = true;
				}
				if ( c.name.Equals("Move (Vertical)") ) {
					c.GetComponent<MovePlayerVertical>().enabled = true;
				}
				if ( c.name.Equals("Rotate") ) {
					c.GetComponent<RotatePlayer>().enabled = true;
				}
				if ( c.name.Equals("Move") ) {
					c.GetComponent<MovePlayer>().enabled = true;
				}
			} else {
				if ( c.name.Contains("Move (Horizontal)") ) {
					c.GetComponent<MovePlayerHorizontal>().enabled = false;
				}
				if ( c.name.Equals("Move (Vertical)") ) {
					c.GetComponent<MovePlayerVertical>().enabled = false;
				}
				if ( c.name.Equals("Rotate") ) {
					c.GetComponent<RotatePlayer>().enabled = false;
				}
				if ( c.name.Equals("Move") ) {
					c.GetComponent<MovePlayer>().enabled = false;
				}
			}
		}
	}


}

