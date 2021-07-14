using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

	public player2 character;

	// Use this for initialization
	void Start () {
		character = this.GetComponent<player2> ();

	}
	
	// Update is called once per frame
	void Update () {
		character.Move (Input.GetAxis("Horizontal2"));

		//Esto es para el salto
		if(Input.GetKeyDown(KeyCode.H)){
			character.Jump ();
		}
	}


}
