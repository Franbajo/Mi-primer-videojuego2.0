using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public player1 owner;

	[HideInInspector]


	// Use this for initialization
	void Start () {
		owner = this.GetComponent<player1> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		owner. Move (Input.GetAxis ("Horizontal"), Input.GetAxis("Vertical")); /*Una vez hecho las variables horizontal y vertical relacionadas con el float dir X e Y... Le ponemos los GetAxis para que 
		                                                                         el player lo pueda mover comodamente*/
		if (Input.GetKeyDown (KeyCode.Space)) {
		
			owner.Jump ();
		}
		/* CODIGO made in MIO, PARA EL APUNTADO */
		if (Input.GetKeyDown (KeyCode.L)) {
			
			owner.quieto = true;
			owner.speed = 0;
		} else if (Input.GetKeyUp (KeyCode.L)) {
			owner.quieto = false;
			owner.speed = 2;
		}
			
}

}