using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroce : MonoBehaviour {
	public GameObject plataformainicial; 
	public GameObject semidestroce; 
	public GameObject destroce;
	public GameObject temblor;
	public int salud = 100;

	public GameObject particle;
	public GameObject particle2;
	public BoxCollider2D bc2d;




	//GameObject mainCamera; //CAAAAAAAAAAAMARAAAAAAAAAA TEMBLOOOOOOOOORRRRRRRR



	void Start () {
		
		//mainCamera = GameObject.FindGameObjectWithTag ("MainCamera"); //CAAAAAAAAAAAMARAAAAAAAAAA TEMBLOOOOOOOOORRRRRRRR
		temblor.gameObject.SetActive(false);
		plataformainicial.gameObject.SetActive (true);
		semidestroce.gameObject.SetActive (false);
		destroce.gameObject.SetActive (false);
		particle.gameObject.SetActive (false);
		particle2.gameObject.SetActive (false);
	}

	public void TakeDamage (int damage){
		
		salud -= damage;

		if  (salud==50) {
			plataformainicial.gameObject.SetActive (false);
			semidestroce.gameObject.SetActive (true);
		} 
		else if (salud <= 0) {

			temblor.gameObject.SetActive(true);


			Die ();
		
		} 
	}	
	void Die ()
	{
		plataformainicial.gameObject.SetActive (false);
		semidestroce.gameObject.SetActive (false);
		destroce.gameObject.SetActive (true);
		particle.gameObject.SetActive (true);
		particle2.gameObject.SetActive (true);
		Destroy (bc2d);
		Destroy (temblor.gameObject);
	
		//mainCamera.GetComponent<Camera_Temblor>().ActiveShake(); //CAAAAAAAAAAAMARAAAAAAAAAA TEMBLOOOOOOOOORRRRRRRR

	}



}
