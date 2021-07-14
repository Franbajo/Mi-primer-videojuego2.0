using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo_temblor : MonoBehaviour {

	public GameObject mainCamera;
	private bool vida= false;


	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera"); 
	
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.GetComponent<Camera_Temblor> ().ActiveShake ();
		vida = true;
		if (vida = true) {
			Die ();
		}
	
	}
		
	void Die ()
	{   

		Destroy (gameObject);

		// mainCamera.GetComponent<Camera_Temblor>().ActiveShake(); //CAAAAAAAAAAAMARAAAAAAAAAA TEMBLOOOOOOOOORRRRRRRR

	}


}
