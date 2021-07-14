using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flechita_Indicacion : MonoBehaviour {


	public player1 owner;
	public bool m_FacingRight = true;


	// Use this for initialization
	void Start () {
		
	}
	
	void Update () 
	{
		Vector3 characterScale = transform.localScale;
		if (Input.GetAxis ("Horizontal")<0 ) {
			characterScale.x = -1;
		
		}if (Input.GetAxis ("Horizontal")>0)

			characterScale.x = 1;

		transform.localScale = characterScale;
	} 
}

